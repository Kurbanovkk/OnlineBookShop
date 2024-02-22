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
        public string Index(int id)
        {
            var product = _productRepository.TryGetById(id);
            if (product == null) return $"Продукта с {id} - не существует";
            else return $"{product}\n{product.Description}";
        }
    }
}
