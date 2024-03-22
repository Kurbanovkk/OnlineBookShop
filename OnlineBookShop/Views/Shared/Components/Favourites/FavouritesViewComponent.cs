using Microsoft.AspNetCore.Mvc;

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
            var favouritesCount = favourites?.Amount ?? 0;
            return View("Favourites", favouritesCount);
        }
    }
}
