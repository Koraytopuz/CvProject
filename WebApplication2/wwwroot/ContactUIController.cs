using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.wwwroot
{
    public class ContactUIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
