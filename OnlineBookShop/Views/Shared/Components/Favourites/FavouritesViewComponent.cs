using Microsoft.AspNetCore.Mvc;
using OnlineBookShop.Db;
using OnlineBookShop.Helpers;

namespace OnlineBookShop.Views.Shared.Components.Favourites
{
    public class FavouritesViewComponent : ViewComponent
    {
        private readonly IFavouritesRepository _favouritesRepository;

        public FavouritesViewComponent(IFavouritesRepository favouritesRepository)
            {
                _favouritesRepository = favouritesRepository;
            }

        public IViewComponentResult Invoke()
        {
            var favourites = _favouritesRepository.TryGetByUserId(Constants.UserId);
            var cartViewModel = Mapping.ToFavouritesViewModel(favourites);
            var favouritesCount = cartViewModel?.Amount ?? 0;
            return View("Favourites", favouritesCount);
        }
    }
}
