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
    public class type_accController : ControllerBase
    {
        private readonly paymentsystemContext _context;

        public type_accController(paymentsystemContext context)
        {
            _context = context;
        }

        // GET: api/type_acc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<type_acc>>> Gettype_acc()
        {
            return await _context.type_acc.ToListAsync();
        }

        // GET: api/type_acc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<type_acc>> Gettype_acc(int id)
        {
            var type_acc = await _context.type_acc.FindAsync(id);

            if (type_acc == null)
            {
                return NotFound();
            }

            return type_acc;
        }

        // PUT: api/type_acc/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttype_acc(int id, type_acc type_acc)
        {
            if (id != type_acc.id_type_acc)
            {
                return BadRequest();
            }

            _context.Entry(type_acc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!type_accExists(id))
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

        // POST: api/type_acc
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<type_acc>> Posttype_acc(type_acc type_acc)
        {
            _context.type_acc.Add(type_acc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettype_acc", new { id = type_acc.id_type_acc }, type_acc);
        }

        // DELETE: api/type_acc/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<type_acc>> Deletetype_acc(int id)
        {
            var type_acc = await _context.type_acc.FindAsync(id);
            if (type_acc == null)
            {
                return NotFound();
            }

            _context.type_acc.Remove(type_acc);
            await _context.SaveChangesAsync();

            return type_acc;
        }

        private bool type_accExists(int id)
        {
            return _context.type_acc.Any(e => e.id_type_acc == id);
        }
    }
}
