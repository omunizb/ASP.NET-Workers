using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Empleats.Models;

namespace Empleats.Controllers
{
    [Route("api/EmpleatItems")]
    [ApiController]
    public class EmpleatItemsController : ControllerBase
    {
        private readonly EmpleatContext _context;

        public EmpleatItemsController(EmpleatContext context)
        {
            _context = context;
        }

        // GET: api/EmpleatItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpleatItem>>> GetEmpleatItems()
        {
            return await _context.EmpleatItems.ToListAsync();
        }

        // GET: api/EmpleatItems/5
        [HttpGet("{id}")]

        public async Task<ActionResult<EmpleatItem>> GetEmpleatItem(long id)
        {
            var empleatItem = await _context.EmpleatItems.FindAsync(id);

            if (empleatItem == null)
            {
                return NotFound();
            }

            return empleatItem;
        }

        // PUT: api/EmpleatItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleatItem(long id, EmpleatItem empleatItem)
        {
            if (id != empleatItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(empleatItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleatItemExists(id))
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

        // POST: api/EmpleatItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EmpleatItem>> PostEmpleatItem(EmpleatItem empleatItem)
        {
            _context.EmpleatItems.Add(empleatItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmpleatItem), new { id = empleatItem.Id }, empleatItem);
        }

        // DELETE: api/EmpleatItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmpleatItem>> DeleteEmpleatItem(long id)
        {
            var empleatItem = await _context.EmpleatItems.FindAsync(id);
            if (empleatItem == null)
            {
                return NotFound();
            }

            _context.EmpleatItems.Remove(empleatItem);
            await _context.SaveChangesAsync();

            return empleatItem;
        }

        private bool EmpleatItemExists(long id)
        {
            return _context.EmpleatItems.Any(e => e.Id == id);
        }
    }
}
