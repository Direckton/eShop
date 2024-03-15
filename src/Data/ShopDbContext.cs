using Microsoft.EntityFrameworkCore;
using Shop.Models.Products;

namespace Shop.Data
{
    public class ShopDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {
            
        }
    }
}
