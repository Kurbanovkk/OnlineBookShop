using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace OnlineBookShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductsRepository _productRepository;
        public HomeController()
        {
            _productRepository = new ProductsRepository();
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
    }
}
