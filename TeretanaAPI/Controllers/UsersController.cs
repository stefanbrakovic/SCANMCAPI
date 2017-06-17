using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeretanaAPI.Models;

namespace TeretanaAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly TeretanaContext _context;

        public UsersController(TeretanaContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<Users> GetUsers()
        {
            return _context.Users;
        }

        // GET: api/Users/5
        [HttpGet("{cardNumber}")]
        public async Task<IActionResult> GetUsers([FromRoute] string cardNumber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users = await _context.Users.SingleOrDefaultAsync(m => m.CardNumber == cardNumber);

            if (users == null)
            {
                return NotFound();
            }
            string email = users.Mail;
            
            //sendEmail(email);
            return Ok(email);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers([FromRoute] int id, [FromBody] Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users.UserId)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public IActionResult PostUsers([FromBody] Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string spName = "sp_create_new_User";
            string[] inputParamNames = new string[] { "FirstName", "LastName", "Telephone", "Mail", "UserPassword", "UserTypeId", "GenderId", "DateOfBirth", "Street", "City", "StreetNumber" };
            object[] inputParamValues = new object[] {users.FirstName, users.LastName, users.Telephone, users.Mail, users.UserPassword, users.UserTypeId, users.GenderId, users.DateOfBirth,users.Street, users.City, users.StreetNumber};
            string[] outputParamNames = new string[] { "ErrorCode", "ErrorMessage" };
            object[] outputParamValues = new object[] { 0, "" };

            object[] outParams = DataBaseManipulation.DataReaderExtensions.executeStoredProcedure(_context, spName, inputParamNames, inputParamValues, outputParamNames, outputParamValues);
            JsonResult re = new JsonResult(outputParamValues);
            return Ok(re);

            //_context.Users.Add(users);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetUsers", new { id = users.UserId }, users);
        }

        // DELETE: api/Users/123456a789s
        [HttpDelete("{cardNumber}")]
        public async Task<IActionResult> DeleteUsers([FromRoute] string cardNumber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users = await _context.Users.SingleOrDefaultAsync(m => m.CardNumber == cardNumber);
            if (users == null)
            {
                return NotFound();
            }

            _context.Users.Remove(users);
            await _context.SaveChangesAsync();           

            return Ok(users);
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}