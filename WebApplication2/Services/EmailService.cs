//using MailKit.Net.Smtp;
//using Microsoft.Extensions.Options;
//using System.Net;
//using System.Net.Mail;
//using System.Text.Json;
//using System.Text;
//using WebApplication2.wwwroot.Models;
//using SmtpClient = System.Net.Mail.SmtpClient;

//namespace WebApplication2.wwwroot.Services
//{
//    public class EmailService
//    {
//        private readonly HttpClient _httpClient;
//        private readonly string _serviceId = "service_9e5vi7j"; // EmailJS'den aldığınız Service ID
//        private readonly string _templateId = "template_1olahsj"; // EmailJS'den aldığınız Template ID
//        private readonly string _publicKey = "6bMde8ZnGx_ImkxRG"; // EmailJS'den aldığınız Public Key

//        public EmailService(HttpClient httpClient)
//        {
//            _httpClient = httpClient;
//        }

//        public async Task<bool> SendEmailAsync(string toEmail, string name, string message)
//        {
//            var url = "https://api.emailjs.com/api/v1.0/email/send";

//            var payload = new
//            {
//                service_id = _serviceId,
//                template_id = _templateId,
//                user_id = _publicKey,
//                template_params = new
//                {
//                    name = name,
//                    message = message,
//                    to_email = toEmail
//                }
//            };

//            var jsonPayload = JsonSerializer.Serialize(payload);
//            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

//            var response = await _httpClient.PostAsync(url, content);

//            return response.IsSuccessStatusCode;
//        }
//    }
//}

//using System.Net;
//using System.Net.Mail;
//using System.Threading.Tasks;

//namespace WebApplication2.wwwroot.Services
//{
//    public class EmailService
//    {
//        private readonly HttpClient _httpClient;
//        private readonly string _smtpServer = "smtp.your-email-provider.com"; // Replace with your SMTP server
//        private readonly int _smtpPort = 587; // Replace with your SMTP port
//        private readonly string _smtpUsername = "your-email@example.com"; // Replace with your SMTP username
//        private readonly string _smtpPassword = "your-email-password"; // Replace with your SMTP password

//        public EmailService(HttpClient httpClient)
//        {
//            _httpClient = httpClient;
//        }

//        public async Task<bool> SendEmailAsync(string toEmail, string name, string message)
//        {
//            try
//            {
//                var smtpClient = new SmtpClient(_smtpServer)
//                {
//                    Port = _smtpPort,
//                    Credentials = new NetworkCredential(_smtpUsername, _smtpPassword),
//                    EnableSsl = true,
//                };

//                var mailMessage = new MailMessage
//                {
//                    From = new MailAddress(_smtpUsername),
//                    Subject = "Contact Form Submission",
//                    Body = $"Name: {name}\nEmail: {toEmail}\n\nMessage:\n{message}",
//                    IsBodyHtml = false,
//                };
//                mailMessage.To.Add(toEmail);

//                await smtpClient.SendMailAsync(mailMessage);
//                return true;
//            }
//            catch (Exception ex)
//            {
//                // Log the exception (optional)
//                Console.WriteLine($"Error sending email: {ex.Message}");
//                return false;
//            }
//        }
//    }
//}

using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebApplication2.wwwroot.Services
{
    public class EmailService
    {
        private readonly HttpClient _httpClient;
        private readonly string _smtpServer = "smtp.your-email-provider.com"; // Replace with your SMTP server
        private readonly int _smtpPort = 587; // Replace with your SMTP port
        private readonly string _smtpUsername = "your-email@example.com"; // Replace with your SMTP username
        private readonly string _smtpPassword = "your-email-password"; // Replace with your SMTP password

        public EmailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> SendEmailAsync(string toEmail, string name, string message)
        {
            try
            {
                var smtpClient = new SmtpClient(_smtpServer)
                {
                    Port = _smtpPort,
                    Credentials = new NetworkCredential(_smtpUsername, _smtpPassword),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_smtpUsername),
                    Subject = "Contact Form Submission",
                    Body = $"Name: {name}\nEmail: {toEmail}\n\nMessage:\n{message}",
                    IsBodyHtml = false,
                };
                mailMessage.To.Add(toEmail);

                await smtpClient.SendMailAsync(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                Console.WriteLine($"Error sending email: {ex.Message}");
                return false;
            }
        }
    }
}

