using Microsoft.AspNetCore.Mvc;

namespace OnlineBookShop.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class OrdersController : Controller
    {
        private readonly IOrdersRepository _ordersRepository;
        public OrdersController(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }
        public IActionResult Index()
        {
            var orders = _ordersRepository.GetOrders();
            return View(orders);
        }

        public IActionResult EditStatusOrders(Guid id)
        {
            var orders = _ordersRepository.GetOrders();
            var currentOrder = orders.FirstOrDefault(order => order.Id == id);
            return View(currentOrder);
        }

        [HttpPost]
        public IActionResult EditStatusOrders(Guid Id, OrderStatuses Status)
        {
            var orders = _ordersRepository.GetOrders();
            var currentOrder = orders.FirstOrDefault(order => order.Id == Id);
            currentOrder.Status = Status;
            currentOrder.EditStatusOrder = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
            return RedirectToAction("Index");
        }
    }
}
