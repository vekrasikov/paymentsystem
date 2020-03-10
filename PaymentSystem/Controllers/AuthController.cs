using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentSystem.Models;

namespace PaymentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly paymentsystemContext _context;
        public AuthController(paymentsystemContext context)
        {
            _context = context;
        }
        // GET: api/Auth/log?login=login&&password=password
        [HttpGet("log")]
        public async Task<IActionResult> Get(string email, string password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            string hashPassword = Convert.ToBase64String(hash);

            var user = await _context.client.Where(x => x.email == email).
                Where(x => x.password == hashPassword).FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound("Пользователь с данным логином и паролем отсутствует");
            }
            else if (user != null && user.verification == false)
            {
                return NotFound("Для входа в систему надо активировать почту");
            }
            return Ok(user);
        }
        [HttpPost("reg")]
        public async Task<IActionResult> Reg([FromBody] client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (UserNotExists(client.email))
            {
                var md5 = MD5.Create();
                var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(client.password));
                string hashPassword = Convert.ToBase64String(hash);
                client.password = hashPassword;
                client.verification = false;
                _context.client.Add(client);
                await _context.SaveChangesAsync();
                return Ok(client);
            }
            return Ok(true);
        }

        private bool UserNotExists(string email)
        {
            if (_context.client.Any(x => x.email == email))
                return false;
            return true;
        }
    }
}