
using Microsoft.AspNetCore.Mvc;

namespace OnlineBookShop.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductsRepository _productRepository;
        private ICartsRepository _cartRepository;
        public CartController(IProductsRepository productRepository, ICartsRepository cartRepository)
        {
            _productRepository = productRepository;
            _cartRepository = cartRepository;
        }

        public ActionResult Index()
        {
            var cart = _cartRepository.TryGetByUserId(Constants.UserId);
            return View(cart);
        }
        public IActionResult Add(int productId)
        {
            var product = _productRepository.TryGetById(productId);
            _cartRepository.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int productId)
        {
            var product = _productRepository.TryGetById(productId);
            _cartRepository.Delete(productId, Constants.UserId);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            _cartRepository.Clear(Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
