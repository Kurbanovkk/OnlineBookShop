namespace OnlineBookShop
{
    public interface IOrdersRepository
    {
        public void AddOrder(Order order);
        public List<Order> GetOrders();
    }
}
