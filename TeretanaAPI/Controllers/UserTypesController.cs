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
    [Route("api/UserTypes")]
    public class UserTypesController : Controller
    {
        private readonly TeretanaContext _context;

        public UserTypesController(TeretanaContext context)
        {
            _context = context;
        }

        // GET: api/UserTypes
        [HttpGet]
        public IEnumerable<UserTypes> GetUserTypes()
        {
            return _context.UserTypes;
        }

        // GET: api/UserTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserTypes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userTypes = await _context.UserTypes.SingleOrDefaultAsync(m => m.UserTypeId == id);

            if (userTypes == null)
            {
                return NotFound();
            }

            return Ok(userTypes);
        }

        // PUT: api/UserTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserTypes([FromRoute] int id, [FromBody] UserTypes userTypes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userTypes.UserTypeId)
            {
                return BadRequest();
            }

            _context.Entry(userTypes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTypesExists(id))
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

        // POST: api/UserTypes
        [HttpPost]
        public async Task<IActionResult> PostUserTypes([FromBody] UserTypes userTypes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UserTypes.Add(userTypes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserTypes", new { id = userTypes.UserTypeId }, userTypes);
        }

        // DELETE: api/UserTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserTypes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userTypes = await _context.UserTypes.SingleOrDefaultAsync(m => m.UserTypeId == id);
            if (userTypes == null)
            {
                return NotFound();
            }

            _context.UserTypes.Remove(userTypes);
            await _context.SaveChangesAsync();

            return Ok(userTypes);
        }

        private bool UserTypesExists(int id)
        {
            return _context.UserTypes.Any(e => e.UserTypeId == id);
        }
    }
}