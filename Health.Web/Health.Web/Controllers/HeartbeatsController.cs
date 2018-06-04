using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Health.Web.Controllers
{
    public class HeartbeatsController : BaseController
    {
        public async Task<IActionResult> Index() => View();
    }
}