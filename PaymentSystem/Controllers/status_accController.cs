using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentSystem.Models;

namespace PaymentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class status_accController : ControllerBase
    {
        private readonly paymentsystemContext _context;

        public status_accController(paymentsystemContext context)
        {
            _context = context;
        }

        // GET: api/status_acc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<status_acc>>> Getstatus_acc()
        {
            return await _context.status_acc.ToListAsync();
        }

        // GET: api/status_acc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<status_acc>> Getstatus_acc(int id)
        {
            var status_acc = await _context.status_acc.FindAsync(id);

            if (status_acc == null)
            {
                return NotFound();
            }

            return status_acc;
        }

        // PUT: api/status_acc/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putstatus_acc(int id, status_acc status_acc)
        {
            if (id != status_acc.id_status_acc)
            {
                return BadRequest();
            }

            _context.Entry(status_acc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!status_accExists(id))
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

        // POST: api/status_acc
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<status_acc>> Poststatus_acc(status_acc status_acc)
        {
            _context.status_acc.Add(status_acc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getstatus_acc", new { id = status_acc.id_status_acc }, status_acc);
        }

        // DELETE: api/status_acc/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<status_acc>> Deletestatus_acc(int id)
        {
            var status_acc = await _context.status_acc.FindAsync(id);
            if (status_acc == null)
            {
                return NotFound();
            }

            _context.status_acc.Remove(status_acc);
            await _context.SaveChangesAsync();

            return status_acc;
        }

        private bool status_accExists(int id)
        {
            return _context.status_acc.Any(e => e.id_status_acc == id);
        }
    }
}
