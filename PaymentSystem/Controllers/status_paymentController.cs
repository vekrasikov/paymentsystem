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
    public class status_paymentController : ControllerBase
    {
        private readonly paymentsystemContext _context;

        public status_paymentController(paymentsystemContext context)
        {
            _context = context;
        }

        // GET: api/status_payment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<status_payment>>> Getstatus_payment()
        {
            return await _context.status_payment.ToListAsync();
        }

        // GET: api/status_payment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<status_payment>> Getstatus_payment(int id)
        {
            var status_payment = await _context.status_payment.FindAsync(id);

            if (status_payment == null)
            {
                return NotFound();
            }

            return status_payment;
        }

        // PUT: api/status_payment/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putstatus_payment(int id, status_payment status_payment)
        {
            if (id != status_payment.id_status_payment)
            {
                return BadRequest();
            }

            _context.Entry(status_payment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!status_paymentExists(id))
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

        // POST: api/status_payment
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<status_payment>> Poststatus_payment(status_payment status_payment)
        {
            _context.status_payment.Add(status_payment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getstatus_payment", new { id = status_payment.id_status_payment }, status_payment);
        }

        // DELETE: api/status_payment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<status_payment>> Deletestatus_payment(int id)
        {
            var status_payment = await _context.status_payment.FindAsync(id);
            if (status_payment == null)
            {
                return NotFound();
            }

            _context.status_payment.Remove(status_payment);
            await _context.SaveChangesAsync();

            return status_payment;
        }

        private bool status_paymentExists(int id)
        {
            return _context.status_payment.Any(e => e.id_status_payment == id);
        }
    }
}
