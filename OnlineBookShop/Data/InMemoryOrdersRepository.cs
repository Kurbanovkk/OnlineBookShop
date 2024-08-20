
namespace OnlineBookShop
{
    public class InMemoryOrdersRepository : IOrdersRepository
    {

        private List<OrderViewModel> _orders = new List<OrderViewModel>();

        public void AddOrder(OrderViewModel order)
        {
            _orders.Add(order);
        }

        public List<OrderViewModel> GetOrders()
        {
            return _orders;
        }

    }
}
