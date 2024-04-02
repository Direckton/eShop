using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models.Products;
using System.Collections.Generic;

namespace Shop.Controllers
{
    

    public class InventoryController : Controller
    {

        private readonly ShopDbContext _context;

        public InventoryController(ShopDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            var inventory = await _context.Inventory.ToListAsync();
            var list = ProductPlusInventory.ToList(await _context.Products.ToListAsync(), await _context.Inventory.ToListAsync());
            return View(list);
        }
    }
}
