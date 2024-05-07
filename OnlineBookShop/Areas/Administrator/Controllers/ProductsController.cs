using Microsoft.AspNetCore.Mvc;

namespace OnlineBookShop
{
    [Area("Administrator")]
    public class ProductsController : Controller
    {
        private readonly IProductsRepository _productRepository;
        public ProductsController(IProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            var products = _productRepository.GetProducts();

            return View(products);
        }

        public IActionResult Del(int id)
        {
            _productRepository.Del(id);
            return RedirectToAction("Index");
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(ProductEdit newProduct)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
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
        public IActionResult EditProduct(ProductEdit productEdit, int id)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            var currentProduct = _productRepository.TryGetById(id);
            currentProduct.Name = productEdit.Name;
            currentProduct.Cost = productEdit.Cost;
            currentProduct.Description = productEdit.Description;
            currentProduct.Link = productEdit.Link;
            return RedirectToAction("Index");
        }
    }
}
