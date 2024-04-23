using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookShop;

namespace OnlineBookShop.Controllers
{
    public class AdministratorController : Controller
    {

        private readonly IProductsRepository _productRepository;
        private readonly IOrdersRepository _ordersRepository;
        public AdministratorController(IProductsRepository productRepository, IOrdersRepository ordersRepository)
        {
            _productRepository = productRepository;
            _ordersRepository = ordersRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetOrders()
        {
            var orders = _ordersRepository.GetOrders();
            return View(orders);
        }

        public IActionResult GetUsers()
        {
            return View();
        }

        public IActionResult GetRoles()
        {
            return View();
        }

        public IActionResult GetProducts()
        {
            var products = _productRepository.GetProducts();

            return View(products);
        }

        public IActionResult Del(int id)
        {
            _productRepository.Del(id);
            return RedirectToAction("GetProducts");
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(ProductEdit newProduct) 
        {
            var product = _productRepository.GetProducts();
            product.Add(new Product(newProduct.Name, newProduct.Description, newProduct.Cost, newProduct.Link));
            return View();
        }

        public IActionResult EditProduct(int id)
        {
            var product = _productRepository.TryGetById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(ProductEdit productEdit,int id) 
        { 
            var currentProduct = _productRepository.TryGetById(id);
            currentProduct.Name = productEdit.Name;
            currentProduct.Cost = productEdit.Cost;
            currentProduct.Description = productEdit.Description;
            currentProduct.Link = productEdit.Link;
            return RedirectToAction("GetProducts");
        }
    }
}
