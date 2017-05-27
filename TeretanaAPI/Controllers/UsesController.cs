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
    [Route("api/Uses")]
    public class UsesController : Controller
    {
        private readonly TeretanaContext _context;

        public UsesController(TeretanaContext context)
        {
            _context = context;
        }

        // GET: api/Uses
        [HttpGet]
        public IEnumerable<Uses> GetUses()
        {
            return _context.Uses;
        }

        // GET: api/Uses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUses([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var uses = await _context.Uses.SingleOrDefaultAsync(m => m.UsageId == id);

            if (uses == null)
            {
                return NotFound();
            }

            return Ok(uses);
        }

        // PUT: api/Uses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUses([FromRoute] int id, [FromBody] Uses uses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != uses.UsageId)
            {
                return BadRequest();
            }

            _context.Entry(uses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsesExists(id))
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

        // POST: api/Uses
        [HttpPost]
        public async Task<IActionResult> PostUses([FromBody] Uses uses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Uses.Add(uses);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UsesExists(uses.UsageId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUses", new { id = uses.UsageId }, uses);
        }

        // DELETE: api/Uses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUses([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var uses = await _context.Uses.SingleOrDefaultAsync(m => m.UsageId == id);
            if (uses == null)
            {
                return NotFound();
            }

            _context.Uses.Remove(uses);
            await _context.SaveChangesAsync();

            return Ok(uses);
        }

        private bool UsesExists(int id)
        {
            return _context.Uses.Any(e => e.UsageId == id);
        }
    }
}