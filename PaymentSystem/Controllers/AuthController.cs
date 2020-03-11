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
using MimeKit;
using MailKit.Net.Smtp;



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
                await SendEmailAsync(client.email,client.id_client);
                await _context.SaveChangesAsync();
                return Ok(client);
            }
            return Ok(true);
        }
        public async Task SendEmailAsync(string email, int id)
        {
            var emailMessage = new MimeMessage();
            string link = "https://localhost:44304/api/confirmEmail?id=";
            string message = String.Format("Чтобы авторизоваться в системе платежей PaymentSystem, перейдите по ссылке - {0}{1}", link, id);
            emailMessage.From.Add(new MailboxAddress("PAYMENTSYSTEM", "istpshm@yandex.ru"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = "Подтверждение почты";
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.yandex.ru", 465, true);
                await client.AuthenticateAsync("istpshm@yandex.ru", "honeyMONEY");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
        private bool UserNotExists(string email)
        {
            if (_context.client.Any(x => x.email == email))
                return false;
            return true;
        }
        private void SendMail(string email,string message)
        {
            
        }
        // GET: api/Auth/confirmEmail?id=1
        [HttpGet("confirmEmail")]
        public async Task<IActionResult> ConfirmEmail(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var client = await _context.client.FindAsync(id);
            if (client == null)
            {
                return NotFound("Пользователь с данным логином и паролем отсутствует");
            }
            else if (client != null && client.verification == false)
            {
                client.verification = true;
                return Ok(client);
            }
            return NotFound("Данный пользователь уже подтвердил почту");
        }
    }
}