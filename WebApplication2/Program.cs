////using WebApplication2.wwwroot.Models;
////using WebApplication2.wwwroot.Services;

////var builder = WebApplication.CreateBuilder(args);
////builder.Services.AddHttpClient();
////builder.Services.AddSingleton<EmailService>();
////builder.Services.AddCors(options =>
////{
////    options.AddPolicy("AllowAll",
////        builder => builder.AllowAnyOrigin()
////                          .AllowAnyMethod()
////                          .AllowAnyHeader());
////});
////var app = builder.Build();
////app.MapGet("/", () => "Hello World!");
////app.UseStaticFiles();

////app.MapPost("/send-email", async (HttpContext context, EmailService emailService) =>
////{
////    var form = await context.Request.ReadFromJsonAsync<EmailRequest>();
////    if (form == null)
////    {
////        return Results.BadRequest("Invalid Request");
////    }

////    var success = await emailService.SendEmailAsync(form.ToEmail, form.Name, form.Message);

////    return success ? Results.Ok("E-mail Sent Successfully!") : Results.StatusCode(500);
////});
////app.UseCors("AllowAll"); // CORS kullanýmý
////app.UseAuthorization();
////app.MapControllers();
////app.Run();
////public class EmailRequest
////{
////    public string ToEmail { get; set; } = "";
////    public string Name { get; set; } = "";
////    public string Message { get; set; } = "";
////}
////using WebApplication2.wwwroot.Models;
////using WebApplication2.wwwroot.Services;

////var builder = WebApplication.CreateBuilder(args);

////// Add services to the container.
////builder.Services.AddHttpClient();
////builder.Services.AddSingleton<EmailService>();
////builder.Services.AddCors(options =>
////{
////    options.AddPolicy("AllowAll",
////        builder => builder.AllowAnyOrigin()
////                          .AllowAnyMethod()
////                          .AllowAnyHeader());
////});
////builder.Services.AddAuthorization(); // Add authorization services
////builder.Services.AddControllers(); // Add controller services

////var app = builder.Build();

////// Configure the HTTP request pipeline.
////app.UseHttpsRedirection();
////app.UseStaticFiles();
////app.UseCors("AllowAll"); // CORS kullanýmý
////app.UseAuthorization(); // Use authorization middleware

////app.MapGet("/", () => "Hello World!");

////app.MapPost("/api/contact/send", async (HttpContext context, EmailService emailService) =>
////{
////    var form = await context.Request.ReadFromJsonAsync<EmailRequest>();
////    if (form == null)
////    {
////        return Results.BadRequest("Invalid Request");
////    }

////    var success = await emailService.SendEmailAsync(form.ToEmail, form.Name, form.Message);

////    return success ? Results.Ok("E-mail Sent Successfully!") : Results.StatusCode(500);
////});

////app.MapControllers();
////app.Run();

////public class EmailRequest
////{
////    public string ToEmail { get; set; } = "";
////    public string Name { get; set; } = "";
////    public string Message { get; set; } = "";
////}
//using WebApplication2.wwwroot.Models;
//using WebApplication2.wwwroot.Services;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddHttpClient();
//builder.Services.AddSingleton<EmailService>();
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll",
//        builder => builder.AllowAnyOrigin()
//                          .AllowAnyMethod()
//                          .AllowAnyHeader());
//});
//builder.Services.AddAuthorization(); // Add authorization services
//builder.Services.AddControllers(); // Add controller services
//var app = builder.Build();

//// Configure the HTTP request pipeline.
//app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseCors("AllowAll"); // CORS kullanýmý
//app.UseAuthorization(); // Use authorization middleware

//app.MapGet("/", () => "Hello World!");

//app.MapControllers();
//app.MapPost("/api/contact/send", async (HttpContext context, EmailService emailService) =>
//{
//    try
//    {
//        var form = await context.Request.ReadFromJsonAsync<EmailRequest>();
//        if (form == null)
//        {
//            return Results.BadRequest("Invalid Request");
//        }

//        var success = await emailService.SendEmailAsync(form.ToEmail, form.Name, form.Message);

//        return success ? Results.Ok("E-mail Sent Successfully!") : Results.Problem("Error sending email: Failure sending mail.", statusCode: 500);
//    }
//    catch (Exception ex)
//    {
//        // Log the exception (optional)
//        Console.WriteLine($"Error processing request: {ex.Message}");
//        return Results.Problem("Internal Server Error", statusCode: 500);
//    }
//});

//app.Run();

//public class EmailRequest
//{
//    public string ToEmail { get; set; } = "";
//    public string Name { get; set; } = "";
//    public string Message { get; set; } = "";
//}
using WebApplication2.wwwroot.Models;
using WebApplication2.wwwroot.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddSingleton<EmailService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});
builder.Services.AddAuthorization(); // Add authorization services
builder.Services.AddControllersWithViews(); // Add controller services with views

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("AllowAll"); // CORS kullanýmý
app.UseAuthorization(); // Use authorization middleware

app.MapGet("/", () => "Hello World!");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

public class EmailRequest
{
    public string ToEmail { get; set; } = "";
    public string Name { get; set; } = "";
    public string Message { get; set; } = "";
}


