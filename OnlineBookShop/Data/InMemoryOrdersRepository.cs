
namespace OnlineBookShop
{
    public class InMemoryOrdersRepository : IOrdersRepository
    {

        private List<Order> _orders = new List<Order>();

        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }

        public List<Order> GetOrders()
        {
            return _orders;
        }
    }
}
