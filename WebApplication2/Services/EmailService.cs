using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using WebApplication2.wwwroot.Models;
using SmtpClient = System.Net.Mail.SmtpClient;

namespace WebApplication2.wwwroot.Services
{
    public class EmailService
    {
        private readonly SmtpSettings _smtpSettings;

        public EmailService(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public async Task SendEmailAsync(string name, string email, string message)
        {
            var smtpClient = new SmtpClient(_smtpSettings.Server)
            {
                Port = _smtpSettings.Port,
                Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_smtpSettings.FromEmail),
                Subject = "New Contact Form Message",
                Body = $"Name: {name}\nEmail: {email}\nMessage: {message}",
                IsBodyHtml = false
            };

            mailMessage.To.Add(_smtpSettings.FromEmail);

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
