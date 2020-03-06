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
    public class credit_rateController : ControllerBase
    {
        private readonly paymentsystemContext _context;

        public credit_rateController(paymentsystemContext context)
        {
            _context = context;
        }

        // GET: api/credit_rate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<credit_rate>>> Getcredit_rate()
        {
            return await _context.credit_rate.ToListAsync();
        }

        // GET: api/credit_rate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<credit_rate>> Getcredit_rate(int id)
        {
            var credit_rate = await _context.credit_rate.FindAsync(id);

            if (credit_rate == null)
            {
                return NotFound();
            }

            return credit_rate;
        }

        // PUT: api/credit_rate/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcredit_rate(int id, credit_rate credit_rate)
        {
            if (id != credit_rate.id_credit_rate)
            {
                return BadRequest();
            }

            _context.Entry(credit_rate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!credit_rateExists(id))
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

        // POST: api/credit_rate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<credit_rate>> Postcredit_rate(credit_rate credit_rate)
        {
            _context.credit_rate.Add(credit_rate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcredit_rate", new { id = credit_rate.id_credit_rate }, credit_rate);
        }

        // DELETE: api/credit_rate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<credit_rate>> Deletecredit_rate(int id)
        {
            var credit_rate = await _context.credit_rate.FindAsync(id);
            if (credit_rate == null)
            {
                return NotFound();
            }

            _context.credit_rate.Remove(credit_rate);
            await _context.SaveChangesAsync();

            return credit_rate;
        }

        private bool credit_rateExists(int id)
        {
            return _context.credit_rate.Any(e => e.id_credit_rate == id);
        }
    }
}
