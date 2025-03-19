using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.ViewComponents.ContactControllerPartial
{
    public class _ContactPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
