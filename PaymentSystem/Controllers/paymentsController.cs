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
    public class paymentsController : ControllerBase
    {
        private readonly paymentsystemContext _context;

        public paymentsController(paymentsystemContext context)
        {
            _context = context;
        }

        // GET: api/payments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<payment>>> Getpayment()
        {
            return await _context.payment.ToListAsync();
        }

        // GET: api/payments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<payment>> Getpayment(int id)
        {
            var payment = await _context.payment.FindAsync(id);

            if (payment == null)
            {
                return NotFound();
            }

            return payment;
        }

        // PUT: api/payments/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putpayment(int id, payment payment)
        {
            if (id != payment.id_payment)
            {
                return BadRequest();
            }

            _context.Entry(payment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!paymentExists(id))
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

        // POST: api/payments
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<payment>> Postpayment(payment payment)
        {
            _context.payment.Add(payment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getpayment", new { id = payment.id_payment }, payment);
        }

        // DELETE: api/payments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<payment>> Deletepayment(int id)
        {
            var payment = await _context.payment.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            _context.payment.Remove(payment);
            await _context.SaveChangesAsync();

            return payment;
        }

        private bool paymentExists(int id)
        {
            return _context.payment.Any(e => e.id_payment == id);
        }
    }
}
