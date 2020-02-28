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
    public class autopaymentsController : ControllerBase
    {
        private readonly paymentsystemContext _context;

        public autopaymentsController(paymentsystemContext context)
        {
            _context = context;
        }

        // GET: api/autopayments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<autopayment>>> Getautopayment()
        {
            return await _context.autopayment.ToListAsync();
        }

        // GET: api/autopayments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<autopayment>> Getautopayment(int id)
        {
            var autopayment = await _context.autopayment.FindAsync(id);

            if (autopayment == null)
            {
                return NotFound();
            }

            return autopayment;
        }

        // PUT: api/autopayments/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putautopayment(int id, autopayment autopayment)
        {
            if (id != autopayment.id_autopayment)
            {
                return BadRequest();
            }

            _context.Entry(autopayment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!autopaymentExists(id))
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

        // POST: api/autopayments
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<autopayment>> Postautopayment(autopayment autopayment)
        {
            _context.autopayment.Add(autopayment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getautopayment", new { id = autopayment.id_autopayment }, autopayment);
        }

        // DELETE: api/autopayments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<autopayment>> Deleteautopayment(int id)
        {
            var autopayment = await _context.autopayment.FindAsync(id);
            if (autopayment == null)
            {
                return NotFound();
            }

            _context.autopayment.Remove(autopayment);
            await _context.SaveChangesAsync();

            return autopayment;
        }

        private bool autopaymentExists(int id)
        {
            return _context.autopayment.Any(e => e.id_autopayment == id);
        }
    }
}
