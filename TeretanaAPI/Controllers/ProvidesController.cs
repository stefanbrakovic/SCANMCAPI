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
    [Route("api/Provides")]
    public class ProvidesController : Controller
    {
        private readonly TeretanaContext _context;

        public ProvidesController(TeretanaContext context)
        {
            _context = context;
        }

        // GET: api/Provides
        [HttpGet]
        public IEnumerable<Provides> GetProvides()
        {
            return _context.Provides;
        }

        // GET: api/Provides/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProvides([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var provides = await _context.Provides.SingleOrDefaultAsync(m => m.ProvidesId == id);

            if (provides == null)
            {
                return NotFound();
            }

            return Ok(provides);
        }

        // PUT: api/Provides/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProvides([FromRoute] int id, [FromBody] Provides provides)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != provides.ProvidesId)
            {
                return BadRequest();
            }

            _context.Entry(provides).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvidesExists(id))
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

        // POST: api/Provides
        [HttpPost]
        public async Task<IActionResult> PostProvides([FromBody] Provides provides)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Provides.Add(provides);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProvidesExists(provides.ProvidesId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProvides", new { id = provides.ProvidesId }, provides);
        }

        // DELETE: api/Provides/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProvides([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var provides = await _context.Provides.SingleOrDefaultAsync(m => m.ProvidesId == id);
            if (provides == null)
            {
                return NotFound();
            }

            _context.Provides.Remove(provides);
            await _context.SaveChangesAsync();

            return Ok(provides);
        }

        private bool ProvidesExists(int id)
        {
            return _context.Provides.Any(e => e.ProvidesId == id);
        }
    }
}