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
    public class status_requestController : ControllerBase
    {
        private readonly paymentsystemContext _context;

        public status_requestController(paymentsystemContext context)
        {
            _context = context;
        }

        // GET: api/status_request
        [HttpGet]
        public async Task<ActionResult<IEnumerable<status_request>>> Getstatus_request()
        {
            return await _context.status_request.ToListAsync();
        }

        // GET: api/status_request/5
        [HttpGet("{id}")]
        public async Task<ActionResult<status_request>> Getstatus_request(int id)
        {
            var status_request = await _context.status_request.FindAsync(id);

            if (status_request == null)
            {
                return NotFound();
            }

            return status_request;
        }

        // PUT: api/status_request/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putstatus_request(int id, status_request status_request)
        {
            if (id != status_request.id_status_request)
            {
                return BadRequest();
            }

            _context.Entry(status_request).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!status_requestExists(id))
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

        // POST: api/status_request
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<status_request>> Poststatus_request(status_request status_request)
        {
            _context.status_request.Add(status_request);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getstatus_request", new { id = status_request.id_status_request }, status_request);
        }

        // DELETE: api/status_request/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<status_request>> Deletestatus_request(int id)
        {
            var status_request = await _context.status_request.FindAsync(id);
            if (status_request == null)
            {
                return NotFound();
            }

            _context.status_request.Remove(status_request);
            await _context.SaveChangesAsync();

            return status_request;
        }

        private bool status_requestExists(int id)
        {
            return _context.status_request.Any(e => e.id_status_request == id);
        }
    }
}
