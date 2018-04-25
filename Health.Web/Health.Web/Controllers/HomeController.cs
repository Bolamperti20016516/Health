using Microsoft.AspNetCore.Mvc;

namespace Health.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Hello Razor";

            return View();
        }
    }
}