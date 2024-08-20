namespace OnlineBookShop.Db.Models
{
    public class Order
    {
        public Guid Id { get; set;}

        public UserDeliveryInfo User { get; set; }
        public List<Cart> Items { get; set; }
        public string CreateOrder { get; set; }
        public string EditStatusOrder { get; set; }
        public OrderStatuses Status { get; set; }
        public decimal Amount { get; set; }
    }
}
