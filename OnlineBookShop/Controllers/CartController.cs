﻿
using Microsoft.AspNetCore.Mvc;
using OnlineBookShop.Db;
using OnlineBookShop.Db.Models;
using OnlineBookShop.Helpers;

namespace OnlineBookShop.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductsRepository _productRepository;
        private ICartsRepository _cartRepository;
        public CartController(IProductsRepository productRepository, ICartsRepository cartRepository)
        {
            _productRepository = productRepository;
            _cartRepository = cartRepository;
        }

        public ActionResult Index()
        {
            var cart = _cartRepository.TryGetByUserId(Constants.UserId);
            return View(Mapping.ToCartViewModel(cart));
        }
        public IActionResult Add(Guid productId)
        {
            var product = _productRepository.TryGetById(productId);
            _cartRepository.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid productId)
        {
            var product = _productRepository.TryGetById(productId);
            _cartRepository.Delete(productId, Constants.UserId);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            _cartRepository.Clear(Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
