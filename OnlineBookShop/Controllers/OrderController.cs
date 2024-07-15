using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;

namespace OnlineBookShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartsRepository _cartsRepository;
        private readonly IOrdersRepository _ordersRepository;

        public OrderController(ICartsRepository cartsRepository, IOrdersRepository ordersRepository)
        {
            _cartsRepository = cartsRepository;
            _ordersRepository = ordersRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Buy(UserDeliveryInfo user)
        {
            if (!user.Name.All(c => char.IsLetter(c) || c == ' '))
            {
                ModelState.AddModelError("", "ФИО должны содержать только буквы");
            }
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            var existingCart = _cartsRepository.TryGetByUserId(Constants.UserId);

            var order = new Order
            {
                User = user,
                Items = existingCart.Carts.Clear
            };
            _ordersRepository.AddOrder(order);
            _cartsRepository.Carts.Clear();
            return View(order);
        }

        public IActionResult Orders()
        {
            var orders = _ordersRepository.GetOrders();
            return View(orders);
        }
    }
}
