using Microsoft.AspNetCore.Mvc;

namespace Health.Web.Controllers
{
    public class HeartbeatController : Controller
    {
        public IActionResult Index() => View();
    }
}