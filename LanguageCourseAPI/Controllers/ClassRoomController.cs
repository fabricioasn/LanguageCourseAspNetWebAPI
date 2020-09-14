using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LanguageCourseAPI.Models;
using LanguageCourseAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;

// https://localhost:5001/v1/categories local address

namespace LanguageCourseAPI.Controllers
{
    [Route("v1/turma")]
    public class ClassRoomController:ControllerBase
    {
        private readonly DataContextAPI _context;
        public ClassRoomController([FromServices] DataContextAPI context)
        {
            _context = context;
        }

        //read classes as a list enumerable      
        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<ActionResult<IEnumerable<ClassRoom>>> Get()
        {
            var categories = await _context.ClassRooms.AsNoTracking().ToListAsync();
            return Ok(categories);
        }

        //get a class by ID    
        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<ClassRoom>> GetClass(int id)
        {
            var categories = await _context.ClassRooms.AsNoTracking().Where(c => c.Id == id).FirstOrDefaultAsync();
            return Ok(categories);
        }


        //create a new class    
        [HttpPost]
        [Route("")]
        [Authorize(Roles = "employee")]
        public async Task<ActionResult<ClassRoom>> PostCategory(
            [FromBody] ClassRoom classModel,
            [FromServices] DataContextAPI dataContext)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _context.ClassRooms.Add(classModel);
                await _context.SaveChangesAsync();
                return Ok(classModel);
            }
            catch
            {
                return BadRequest(new { message = "Não foi possível criar a turma." });
            }

        }

        //uptade an existing class    
        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "employee")]
        public async Task<ActionResult<ClassRoom>> PutClass(int id, [FromBody] ClassRoom classModel)
        {
            if (id != classModel.Id)
            {
                return NotFound(new { message = "Turma não encontrada." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _context.Entry<ClassRoom>(classModel).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok(classModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Turma já atualizada." });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível atualizar a turma." });
            }
        }

        //delete a class in database    
        [HttpDelete]
        [Route("")]
        [Authorize(Roles = "manager")] // only the manager has permission to cascade delete a class
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<ActionResult<ClassRoom>> DeleteClass(int id)
        {
            var classModel = await _context.ClassRooms.FirstOrDefaultAsync(c => c.Id == id);

            if (classModel == null)
            {
                return NotFound(new { message = "Turma não encontrada." });
            }
            try
            {
                // returns badRequest to deletion if the classroom transient have some student
                if (classModel.Students != null)
                {
                    return BadRequest(new
                    {
                        message = "Não é permitido remover esta turma, " +
                        "pois ela ainda possui alunos."
                    });
                }
                _context.ClassRooms.Remove(classModel);
                await _context.SaveChangesAsync();

                return Ok(classModel);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível remover a turma." });
            }
        }


    }


}

