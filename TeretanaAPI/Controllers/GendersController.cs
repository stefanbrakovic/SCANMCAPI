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
    [Route("api/Genders")]
    public class GendersController : Controller
    {
        private readonly TeretanaContext _context;

        public GendersController(TeretanaContext context)
        {
            _context = context;
        }

        // GET: api/Genders
        [HttpGet]
        public IEnumerable<Genders> GetGenders()
        {
            return _context.Genders;
        }

        // GET: api/Genders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenders([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var genders = await _context.Genders.SingleOrDefaultAsync(m => m.GenderId == id);

            if (genders == null)
            {
                return NotFound();
            }

            return Ok(genders);
        }

        // PUT: api/Genders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenders([FromRoute] int id, [FromBody] Genders genders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != genders.GenderId)
            {
                return BadRequest();
            }

            _context.Entry(genders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GendersExists(id))
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

        // POST: api/Genders
        [HttpPost]
        public async Task<IActionResult> PostGenders([FromBody] Genders genders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Genders.Add(genders);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenders", new { id = genders.GenderId }, genders);
        }

        // DELETE: api/Genders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenders([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var genders = await _context.Genders.SingleOrDefaultAsync(m => m.GenderId == id);
            if (genders == null)
            {
                return NotFound();
            }

            _context.Genders.Remove(genders);
            await _context.SaveChangesAsync();

            return Ok(genders);
        }

        private bool GendersExists(int id)
        {
            return _context.Genders.Any(e => e.GenderId == id);
        }
    }
}