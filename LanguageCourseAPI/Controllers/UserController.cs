using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanguageCourseAPI.Services;
using LanguageCourseAPI.Data;
using LanguageCourseAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

// https://localhost:5001/v1/usuario local address
//user manipulation methods

namespace LanguageCourseAPI.Controllers
{
    [Route("v1/usuario")]
    public class UserController : Controller
    {
        private readonly DataContextAPI _context;
        public UserController([FromServices] DataContextAPI context)
        {
            _context = context;
        }

        //create a new User
        [Route("")]
        [HttpPost]
        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<ActionResult<User>> PostUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar o usuário." });
            }
        }

        //validate login by user authentication
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User userModel)
        {
            var user = await _context.Users
            .AsNoTracking()
            .Where(u => u.Username == userModel.Username && u.Password == userModel.Password)
            .FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound(new { message = "Usuário ou senha inválidos ou usuário inexistente." });
            }

            //generates the token to the user submited
            var token = TokenServices.GenerateToken(user);
            user.Password = "##";

            return new
            {
                //returns the validated user and token to the API
                user = user,
                token = token
            };
        }

        //shows all the signed users with restricted acess only to authorized role 'employee'
        [HttpGet]
        [Route("")]
        [Authorize(Roles = "employee")]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var showUsers = await _context
                .Users
                .AsNoTracking()
                .ToListAsync();
            return showUsers;
        }

        //update an existing user with restricted acess only to authorized role 'employee'
        [Route("{id:int}")]
        [HttpPut]
        [Authorize(Roles = "employee")]
        public async Task<ActionResult<User>> PutUser(int id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                return NotFound(new { message = "Usuário não localizado no sistema." });
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _context.Entry<User>(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Usuário já atualizado." });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível atualizar o usuário." });
            }
        }

        //delete an existing user with restricted acess only to authorized role 'manager'
        [Route("")]
        [HttpDelete]
        [Authorize(Roles = "manager")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound(new { message = "Usuário não localizado" });
            }
            try
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível remover o produto" });
            }
        }


    }
}

