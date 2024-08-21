using OnlineBookShop.Db.Models;
namespace OnlineBookShop.Db
{
    public interface IOrdersRepository
    {
        public void AddOrder(Order order);
        public List<Order> GetOrders();
    }
}
