
using Microsoft.AspNetCore.Mvc;

namespace OnlineBookShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductsRepository _productRepository;
        public CartController()
        {
            _productRepository = new ProductsRepository();
        }

        public ActionResult Index()
        {
            var cart = CartsRepository.TryGetByUserId(Constants.UserId);
            return View(cart);
        }
        public IActionResult Add(int productId)
        {
            var product = _productRepository.TryGetById(productId);
            CartsRepository.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
