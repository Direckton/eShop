using System.Linq;

namespace Shop.Models.Products
{

    public class ProductPlusInventory
    {
        public Product product { get; set; }
        public Inventory inventory { get; set; }

        static public List<ProductPlusInventory> ToList(List<Product> product,
            List<Inventory> inventory)
        {
            List<ProductPlusInventory> output = new List<ProductPlusInventory>();
            foreach (var item in product)
            {
                var inv = inventory.Where(x => x.Id == item.InventoryId).FirstOrDefault();
                if (inv != null) {
                
                    output.Add(new ProductPlusInventory
                    {
                        product = item,
                        inventory = inv
                    });
                }
            }
            return output;
        }
    }
    public class Inventory
    {
        public int Id { get; set; }
        public int quantity { get; set; }

    }
}
