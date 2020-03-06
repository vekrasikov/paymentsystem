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
    public class requestsController : ControllerBase
    {
        private readonly paymentsystemContext _context;

        public requestsController(paymentsystemContext context)
        {
            _context = context;
        }

        // GET: api/requests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<request>>> Getrequest()
        {
            return await _context.request.ToListAsync();
        }

        // GET: api/requests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<request>> Getrequest(int id)
        {
            var request = await _context.request.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            return request;
        }

        // PUT: api/requests/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putrequest(int id, request request)
        {
            if (id != request.id_request)
            {
                return BadRequest();
            }

            _context.Entry(request).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!requestExists(id))
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

        // POST: api/requests
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<request>> Postrequest(request request)
        {
            _context.request.Add(request);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getrequest", new { id = request.id_request }, request);
        }

        // DELETE: api/requests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<request>> Deleterequest(int id)
        {
            var request = await _context.request.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            _context.request.Remove(request);
            await _context.SaveChangesAsync();

            return request;
        }

        private bool requestExists(int id)
        {
            return _context.request.Any(e => e.id_request == id);
        }
    }
}
