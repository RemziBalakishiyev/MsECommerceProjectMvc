using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Electronic.App_MS.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
