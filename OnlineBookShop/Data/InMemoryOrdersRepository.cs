
namespace OnlineBookShop.Data
{
    public class InMemoryOrdersRepository : IOrdersRepository
    {
        private List<Cart> _orders = new List<Cart>();

        public void Add(Cart cart)
        {
            _orders.Add(cart);
        }
    }
}
