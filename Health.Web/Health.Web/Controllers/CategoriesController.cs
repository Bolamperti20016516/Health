using Health.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Health.Web.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : CrudController<Category, int>
    { }
}