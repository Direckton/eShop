using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        //First you have to fetch the data to edit
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        //Then you can save it here
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price")] Product product)
        {
            if(id != product.Id)
            {
                return BadRequest();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(_context.Products.Any(e => e.Id == product.Id))
                    {
                        return BadRequest();
                    }
                    else
                    {
                        throw;
                    }

                }
                return RedirectToAction("Index",new {id = product.Id});
            }

            return View(product);
        }
    }
}
