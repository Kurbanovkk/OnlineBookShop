using Microsoft.AspNetCore.Mvc;

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
            var productcounts = cart?.Amount ?? 0;
            return View("Cart", productcounts);
        }
    }
}
