using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Models.Products;

namespace Shop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ShopDbContext _context;

        public ProductController(ShopDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? id)
        {
            //var product = new Product()
            //{
            //    Id = 1,
            //    Name = "Test",
            //    Description = "Test of the description",
            //    Price = 1.2m
            //};

            if (id == null)
            {
                return NotFound();
            }


            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return BadRequest();
            }
            ViewData["Message"] = "Hello from controller";
            return View(product);
        }
    }
}
