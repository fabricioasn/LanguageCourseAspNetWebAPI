﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using LanguageCourseAPI.Models;
using LanguageCourseAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace LanguageCourseAPI.Controllers
{
    public class StudentController:ControllerBase
    {
        private readonly DataContextAPI _context;
        public StudentController([FromServices] DataContextAPI context)
        {
            _context = context;
        }

        //read the students as a list enumerable        
        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<ActionResult<List<Student>>> Get()
        {
            var students = await _context.Students.Include(p => p.ClassRoom).AsNoTracking().ToListAsync();
            return Ok(students);
        }

        //get a student by ID        
        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<Student>> GetProduct(int id)
        {
            var student = await _context.Students.AsNoTracking().Where(p => p.ID == id).FirstOrDefaultAsync();
            return Ok(student);
        }

        //read students as a list enumerable by category        
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<IEnumerable<Student>>> GetProducts(int Id)
        {
            var students = await _context.Students.AsNoTracking().Where(p => p.ClassRoomID == Id).ToListAsync();
            return Ok(students);
        }

        //create a new student        
        [HttpPost]
        [Route("")]
        [Authorize(Roles = "employee")]
        public async Task<ActionResult<Student>> PostProduct([FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();

                return Ok(student);
            }
            catch
            {
                return BadRequest(new { message = "Não foi possível criar @ estudante." });
            }
        }

        //update an existing product        
        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "employee")]
        public async Task<ActionResult<Student>> PutProduct(int id, [FromBody] Student student)
        {
            if (id != student.ID)
            {
                return NotFound(new { message = "Estudante não encontrad@" });
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _context.Entry<Student>(student).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok(student);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Estudante já atualizad@." });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível atualizar @ estudante." });
            }
        }

        //delete a student in database        
        [HttpDelete]
        [Route("")]
        [Authorize(Roles = "employee")] //any employee role user can delete a student
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<ActionResult<Student>> DeleteProduct(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(c => c.ID == id);
            if (student == null)
            {
                return NotFound(new { message = "Estudante não encontrad@." });
            }
            try
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();

                return Ok(student);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível remover @ estudante." });
            }
        }

    }

}
