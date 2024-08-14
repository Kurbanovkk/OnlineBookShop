using Microsoft.AspNetCore.Mvc;
using OnlineBookShop.Helpers;
using OnlineBookShop.Db;

namespace OnlineBookShop.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartsRepository _cartRepository;

        public CartViewComponent(ICartsRepository cartsRepository)
            {
                _cartRepository = cartsRepository;
            }

        public IViewComponentResult Invoke()
        {
            var cart = _cartRepository.TryGetByUserId(Constants.UserId);
            var cartViewModel = Mapping.ToCartViewModel(cart);
            var productcounts = cartViewModel?.Amount ?? 0;
            return View("Cart", productcounts);
        }


    }
}
