using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models.Products;

namespace Shop.Models.SeedData
{
    public class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ShopDbContext(serviceProvider.GetRequiredService<
                DbContextOptions<ShopDbContext>>()))
            {
                if(context.Products.Any())
                {
                    return;
                }
                context.Products.AddRange(
                    new Product
                    {
                        Id = 1,
                        Name = "Test",
                        Description = "Test",
                        Price = 1.20M
                    });
                context.SaveChanges();
            }


        }
    }
}
