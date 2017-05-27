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
    [Route("api/Subscribeds")]
    public class SubscribedsController : Controller
    {
        private readonly TeretanaContext _context;

        public SubscribedsController(TeretanaContext context)
        {
            _context = context;
        }

        // GET: api/Subscribeds
        [HttpGet]
        public IEnumerable<Subscribed> GetSubscribed()
        {
            return _context.Subscribed;
        }

        // GET: api/Subscribeds/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubscribed([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subscribed = await _context.Subscribed.SingleOrDefaultAsync(m => m.SubscribedId == id);

            if (subscribed == null)
            {
                return NotFound();
            }

            return Ok(subscribed);
        }

        // PUT: api/Subscribeds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscribed([FromRoute] int id, [FromBody] Subscribed subscribed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subscribed.SubscribedId)
            {
                return BadRequest();
            }

            _context.Entry(subscribed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscribedExists(id))
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

        // POST: api/Subscribeds
        [HttpPost]
        public async Task<IActionResult> PostSubscribed([FromBody] Subscribed subscribed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Subscribed.Add(subscribed);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SubscribedExists(subscribed.SubscribedId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSubscribed", new { id = subscribed.SubscribedId }, subscribed);
        }

        // DELETE: api/Subscribeds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscribed([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subscribed = await _context.Subscribed.SingleOrDefaultAsync(m => m.SubscribedId == id);
            if (subscribed == null)
            {
                return NotFound();
            }

            _context.Subscribed.Remove(subscribed);
            await _context.SaveChangesAsync();

            return Ok(subscribed);
        }

        private bool SubscribedExists(int id)
        {
            return _context.Subscribed.Any(e => e.SubscribedId == id);
        }
    }
}