using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Hello from controller";
            return View();
        }
    }
}
