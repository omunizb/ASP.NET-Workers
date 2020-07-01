using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Empleats.Models;
using Microsoft.AspNetCore.Cors;

namespace Empleats.Controllers
{
    [Route("api/employees")]
    [ApiController]
    [EnableCors("EmployeesPolicy")]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public EmployeesController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: api/employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        // GET: api/employees/5
        [HttpGet("{id}")]

        public async Task<ActionResult<Employee>> GetEmpleatItem(long id)
        {
            var empleatItem = await _context.Employees.FindAsync(id);

            if (empleatItem == null)
            {
                return NotFound();
            }

            return empleatItem;
        }

        // PUT: api/employees/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleatItem(long id, Employee empleatItem)
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

        // POST: api/employees
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmpleatItem(Employee empleatItem)
        {
            _context.Employees.Add(empleatItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmpleatItem), new { id = empleatItem.Id }, empleatItem);
        }

        // DELETE: api/EmpleatItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmpleatItem(long id)
        {
            var empleatItem = await _context.Employees.FindAsync(id);
            if (empleatItem == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(empleatItem);
            await _context.SaveChangesAsync();

            return empleatItem;
        }

        private bool EmpleatItemExists(long id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
