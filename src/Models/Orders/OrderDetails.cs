namespace Shop.Models.Orders
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Total { get; set; }
    }
}
