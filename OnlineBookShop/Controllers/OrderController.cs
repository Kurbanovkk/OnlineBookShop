using Microsoft.AspNetCore.Mvc;

namespace OnlineBookShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartsRepository _cartsRepository;

        public OrderController(ICartsRepository cartsRepository)
        {
            _cartsRepository = cartsRepository;
        }
        public IActionResult Index()
        {
            var cart = _cartsRepository.TryGetByUserId(Constants.UserId);
            return View(cart);
        }

        public IActionResult Order()
        {
            _cartsRepository.Clear(Constants.UserId);
            return View("/Views/Order/OrderEnd.cshtml");
        }
    }
}
