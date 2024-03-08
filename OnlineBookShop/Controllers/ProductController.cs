using Microsoft.AspNetCore.Mvc;

namespace OnlineBookShop.Controllers
{
    public class ProductController : Controller
    {

        private readonly ProductsRepository _productRepository;
        public ProductController()
        {
            _productRepository = new ProductsRepository();
        }
        public IActionResult Index(int id)
        {
            var product = _productRepository.TryGetById(id);
            
            return View(product);
        }
    }
}
