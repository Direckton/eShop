using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        
        }
    }
}
