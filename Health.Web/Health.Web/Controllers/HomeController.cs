using Health.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Health.Web.Controllers
{
    public class HomeController : Controller
    {
        static readonly string[] Devices = new[]
        {
            "Fitbit Alta",
            "Fitbit Charge 2",
            "Fitbit Ionic",
        };

        public IActionResult Index()
        {
            var random = new Random();

            var model =
                from i in Enumerable.Range(0, 10)
                let deviceId = Devices[random.Next(2)]
                select new Heartbeat
                {
                    Id = i,
                    DeviceId = deviceId,
                    Timestamp = DateTime.Now,
                    Value = random.Next(50, 80),
                };

            return View(model);
        }
    }
}