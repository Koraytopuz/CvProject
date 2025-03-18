using System.Net.Mail;
using System.Net;
using System.Xml.Linq;

namespace WebApplication2
{
    public class Contact
    {
        protected void SendMessage_Click(object sender, EventArgs e)
        {
            string userName = Name.Value; // Name input field
            string userEmail = Email.Value; // Email input field
            string userMessage = Message.Value; // Message textarea

            try
            {
                // E-posta göndermek için MailMessage oluşturuluyor
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("your-email@gmail.com");
                mail.To.Add("your-email@gmail.com"); // Kendi e-posta adresiniz
                mail.Subject = "Contact Form Message from " + userName;
                mail.Body = $"Message from {userName} ({userEmail}):\n\n{userMessage}";

                // SMTP sunucusu ayarları
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("your-email@gmail.com", "your-password"),
                    EnableSsl = true
                };

                // E-posta gönderme işlemi
                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                // Hata durumunda konsola yazdırma
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
