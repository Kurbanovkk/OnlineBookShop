using Microsoft.AspNetCore.Mvc;

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
            var cart = _cartsRepository.TryGetByUserId(Constants.UserId);
            return View(cart);
        }

        [HttpPost]
        public IActionResult Buy(Order order)
        {
            var cart = _cartsRepository.TryGetByUserId(Constants.UserId);
            _ordersRepository.AddOrder(order);
            _ordersRepository.Add(cart);
            _cartsRepository.Clear();
            return View();
        }
    }
}
