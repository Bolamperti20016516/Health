using Microsoft.AspNetCore.Mvc;

namespace Health.Web.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index() => View();
    }
}