﻿using Microsoft.AspNetCore.Mvc;

namespace OnlineBookShop.Controllers
{
    public class FavouritesController : Controller
    {
        private readonly IProductsRepository _productRepository;
        private readonly IFavouritesRepository _favouritesRepository;
        public FavouritesController(IProductsRepository productRepository, IFavouritesRepository favouritesRepository)
        {
            _productRepository = productRepository;
            _favouritesRepository = favouritesRepository;
        }

        public ActionResult Index()
        {
            var favourites = _favouritesRepository.TryGetByUserId(Constants.UserId);
            return View(favourites);
        }
        public IActionResult Add(int productId)
        {
            var product = _productRepository.TryGetById(productId);
            _favouritesRepository.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int productId)
        {
            var product = _productRepository.TryGetById(productId);
            _favouritesRepository.Delete(productId, Constants.UserId);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            _favouritesRepository.Clear();
            return RedirectToAction("Index");
        }
    }
}
