
namespace OnlineBookShop
{
    public class InMemoryOrdersRepository : IOrdersRepository
    {
        private List<Cart> _cart = new List<Cart>();

        private List<Order> _order = new List<Order>();
        public void Add(Cart cart)
        {
            _cart.Add(cart);
        }

        public void AddOrder(Order order)
        {
            _order.Add(order);
        }
    }
}
