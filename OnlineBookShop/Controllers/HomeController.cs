using Microsoft.AspNetCore.Mvc;
using OnlineBookShop.Data;
using OnlineBookShop.Models;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace OnlineBookShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductRepository _productRepository;
        public HomeController()
        {
            _productRepository = new ProductRepository();
        }

        public string Index()
        {
            var products = _productRepository.GetProducts();
            var result = string.Empty;

            foreach (var product in products)
            {
                result += product + "\n\n";
            }
            return result;
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
