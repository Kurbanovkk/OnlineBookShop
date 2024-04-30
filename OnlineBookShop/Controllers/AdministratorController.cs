using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookShop;

namespace OnlineBookShop.Controllers
{
    public class AdministratorController : Controller
    {

        private readonly IProductsRepository _productRepository;
        private readonly IOrdersRepository _ordersRepository;
        private readonly IRolesRepository _rolesRepository;
        public AdministratorController(IProductsRepository productRepository, IOrdersRepository ordersRepository, IRolesRepository rolesRepository)
        {
            _productRepository = productRepository;
            _ordersRepository = ordersRepository;
            _rolesRepository = rolesRepository;
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

        public IActionResult EditStatusOrders(Guid id)
        {
            var orders = _ordersRepository.GetOrders();
            var currentOrder = orders.FirstOrDefault(order => order.Id == id);
            return View(currentOrder);
        }

        [HttpPost]
        public IActionResult EditStatusOrders(Guid Id, OrderStatuses Status)
        {
            var orders = _ordersRepository.GetOrders();
            var currentOrder = orders.FirstOrDefault(order => order.Id == Id);
            currentOrder.Status = Status;
            currentOrder.EditStatusOrder = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
            return RedirectToAction("GetOrders");
        }

        public IActionResult GetUsers()
        {
            return View();
        }

        public IActionResult GetRoles()
        {
            var roles = _rolesRepository.GetAllRoles();
            return View(roles);
        }
        public IActionResult AddRoles()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRoles(Roles role)
        {
            var roles = _rolesRepository.GetAllRoles();
            if (roles.FirstOrDefault(r => r.Name == role.Name) != null)
            {
                ModelState.AddModelError("", "Такая роль уже есть");
            }
            if (!ModelState.IsValid)
            {
                return View(role);
            }
            _rolesRepository.Add(role);
            return RedirectToAction("GetRoles");
        }

        [HttpPost]
        public IActionResult DelRoles(string Name)
        {
            var roles = _rolesRepository.GetAllRoles();
            var currentRole = roles.FirstOrDefault(role => role.Name == Name);
            _rolesRepository.Del(currentRole);
            return RedirectToAction("GetRoles");
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
            return RedirectToAction("GetProducts");
        }

    }
}
