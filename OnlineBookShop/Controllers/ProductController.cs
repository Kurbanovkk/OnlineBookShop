using Microsoft.AspNetCore.Mvc;
using OnlineBookShop.Data;

namespace OnlineBookShop.Controllers
{
    public class ProductController : Controller
    {

        private readonly ProductRepository _productRepository;
        public ProductController()
        {
            _productRepository = new ProductRepository();
        }
        public IActionResult Index(int id)
        {
            var product = _productRepository.TryGetById(id);
            
            return View(product);
        }
    }
}
