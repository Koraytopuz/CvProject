using Microsoft.AspNetCore.Mvc;
using WebApplication2.wwwroot.Services;
namespace WebApplication2.Controllers
{
    [Route("contact")]
    public class ContactController : Controller
    {
        private readonly EmailService _emailService;

        public ContactController(EmailService emailService)
        {
            _emailService = emailService;
        }

        // POST /contact/send-email
        [HttpPost("send-email")]
        public async Task<IActionResult> SendEmail([FromBody] ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                var success = await _emailService.SendEmailAsync(model.ToEmail, model.Name, model.Message);

                if (success)
                {
                    TempData["Message"] = "E-mail sent successfully!";
                    return RedirectToAction("Index"); // Mesaj g�nderildikten sonra y�nlendirme yap�labilir
                }
                else
                {
                    TempData["Message"] = "Error sending email.";
                    return View();
                }
            }
            return View();
        }
    }
}
