using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;

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
			var productsViewModel = new List<ProductViewModel>();
			foreach (var product in products)
			{
				var productViewModel = new ProductViewModel
				{
					Id = product.Id,
					Name = product.Name,
					Cost = product.Cost,
					Description = product.Description,
					Link = product.Link,
				};
				productsViewModel.Add(productViewModel);
			}
			return View(productsViewModel);
        }

        public IActionResult Del(Guid id)
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
            var productDb = new Product
            {
                Name = newProduct.Name,
                Description = newProduct.Description,
                Cost = newProduct.Cost,
                Link = newProduct.Link

            };
            _productRepository.AddProducts(productDb);
            return View();
        }

        public IActionResult EditProduct(Guid id)
        {
            var product = _productRepository.TryGetById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(ProductEdit productEdit, Guid id)
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
