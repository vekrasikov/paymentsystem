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
    public class payment_historyController : ControllerBase
    {
        private readonly paymentsystemContext _context;

        public payment_historyController(paymentsystemContext context)
        {
            _context = context;
        }

        // GET: api/payment_history
        [HttpGet]
        public async Task<ActionResult<IEnumerable<payment_history>>> Getpayment_history()
        {
            return await _context.payment_history.ToListAsync();
        }

        // GET: api/payment_history/5
        [HttpGet("{id}")]
        public async Task<ActionResult<payment_history>> Getpayment_history(int id)
        {
            var payment_history = await _context.payment_history.FindAsync(id);

            if (payment_history == null)
            {
                return NotFound();
            }

            return payment_history;
        }

        // PUT: api/payment_history/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putpayment_history(int id, payment_history payment_history)
        {
            if (id != payment_history.id_payment_history)
            {
                return BadRequest();
            }

            _context.Entry(payment_history).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!payment_historyExists(id))
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

        // POST: api/payment_history
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<payment_history>> Postpayment_history(payment_history payment_history)
        {
            _context.payment_history.Add(payment_history);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getpayment_history", new { id = payment_history.id_payment_history }, payment_history);
        }

        // DELETE: api/payment_history/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<payment_history>> Deletepayment_history(int id)
        {
            var payment_history = await _context.payment_history.FindAsync(id);
            if (payment_history == null)
            {
                return NotFound();
            }

            _context.payment_history.Remove(payment_history);
            await _context.SaveChangesAsync();

            return payment_history;
        }

        private bool payment_historyExists(int id)
        {
            return _context.payment_history.Any(e => e.id_payment_history == id);
        }
    }
}
