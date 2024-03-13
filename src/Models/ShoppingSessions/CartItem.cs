namespace Shop.Models.ShoppingSessions
{
    public class CartItem
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
