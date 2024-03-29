using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace OnlineBookShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository _productRepository;
        public HomeController(IProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var products = _productRepository.GetProducts();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Search(string name)
        {
            if (name != null)
            {
                var products = _productRepository.GetProducts();
                var findProduct = products.Where(product => product.Name.ToLower().Equals(name.ToLower())).ToList();
                return View(findProduct);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
