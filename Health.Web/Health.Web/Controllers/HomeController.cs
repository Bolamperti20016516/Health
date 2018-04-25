using Health.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Health.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new[]
            {
                new Person { Id = 1, FirstName = "John", LastName = "Smith" },
                new Person { Id = 2, FirstName = "Jim", LastName = "Gordon" },
            };

            return View(model);
        }
    }
}