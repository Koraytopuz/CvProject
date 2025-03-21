using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using WebApplication2.wwwroot.Models;

namespace WebApplication2.Controller
{
    [Route("api/contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IConfiguration _config;

        public ContactController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromBody] ContactFormModel model)
        {
            if (model == null)
                return BadRequest(new { message = "Invalid request" });

            try
            {
                // Get SMTP settings from appsettings.json
                var smtpServer = _config["EmailSettings:SmtpServer"];
                var smtpPort = int.Parse(_config["EmailSettings:Port"]);
                var smtpUser = _config["EmailSettings:Username"];
                var smtpPass = _config["EmailSettings:Password"];
                var fromEmail = _config["EmailSettings:From"];

                var smtpClient = new SmtpClient(smtpServer)
                {
                    Port = smtpPort,
                    Credentials = new NetworkCredential(smtpUser, smtpPass),
                    EnableSsl = true
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(fromEmail),
                    Subject = model.Subject,
                    Body = $"Name: {model.Name}\nEmail: {model.Email}\n\nMessage:\n{model.Message}",
                    IsBodyHtml = false
                };

                mailMessage.To.Add(fromEmail); // E-postanın gideceği adres

                await smtpClient.SendMailAsync(mailMessage);
                return Ok(new { message = "Email sent successfully!" });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { message = "Error sending email: " + ex.Message });
            }

        }
            [HttpGet]
            public IActionResult Index()
            {
                return Ok("Contact UI is working");
            }
    }
}
