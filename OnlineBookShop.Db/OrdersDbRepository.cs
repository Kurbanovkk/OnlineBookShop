using OnlineBookShop.Db.Models;
namespace OnlineBookShop.Db
{
    public class OrdersDbRepository : IOrdersRepository
    {
        private readonly DatabaseContext _databaseContext;

        public OrdersDbRepository (DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void AddOrder(Order order)
        {
			_databaseContext.Order.Add(order);
        }

        public List<Order> GetOrders()
        {
            return _databaseContext.Order.ToList();
        }

    }
}
