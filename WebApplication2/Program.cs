using WebApplication2.wwwroot.Models;
using WebApplication2.wwwroot.Services;

var builder = WebApplication.CreateBuilder(args);
// SMTP ayarlarýný yapýlandýr
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
builder.Services.AddSingleton<EmailService>();

var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();
app.Run();
app.MapPost("/send-email", async (EmailService emailService, string name, string email, string message) =>
{
    await emailService.SendEmailAsync(name, email, message);
    return Results.Ok(new { Message = "Email sent successfully!" });
});
