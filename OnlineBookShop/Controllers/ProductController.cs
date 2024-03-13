using Microsoft.AspNetCore.Mvc;
namespace OnlineBookShop.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductsRepository _productRepository;
        public ProductController(IProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IActionResult Index(int id)
        {
            var product = _productRepository.TryGetById(id);
            
            return View(product);
        }
    }
}
