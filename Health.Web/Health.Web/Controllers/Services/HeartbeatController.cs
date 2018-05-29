using Health.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Health.Web.Controllers.Services
{
    [Route("api/[controller]")]
    public class HeartbeatController : CrudController<Heartbeat, int>
    { }
}