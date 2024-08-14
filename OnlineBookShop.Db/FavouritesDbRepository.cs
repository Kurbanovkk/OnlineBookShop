using Microsoft.EntityFrameworkCore;
using OnlineBookShop.Db.Models;
namespace OnlineBookShop.Db
{
    public class FavouritesDbRepository : IFavouritesRepository
    {
		private readonly DatabaseContext _dataBaseContext;

		public FavouritesDbRepository(DatabaseContext dataBaseContext)
		{
			_dataBaseContext = dataBaseContext;
		}

		public Favourites TryGetByUserId(string userId)
        {
			return _dataBaseContext.Favourites.Include(x => x.FavouritesItems).ThenInclude(x => x.Product).FirstOrDefault(x => x.UserId == userId);
		}

		public void Add(Product product, string userId)
		{
			var existingFavourite = TryGetByUserId(userId);

			if (existingFavourite == null)
			{
				var newFavourite = new Favourites
				{
					UserId = userId
				};
				newFavourite.FavouritesItems = new List<FavouritesItem>
					{
						new FavouritesItem
						{
							Amount = 1,
							Product = product,
							Favourites = newFavourite
						}
					};
				_dataBaseContext.Favourites.Add(newFavourite);
			}
			else
			{
				var existingCartItem = existingFavourite?.FavouritesItems?.FirstOrDefault(x => x.Product.Id == product.Id);

				if (existingCartItem != null)
				{
					existingCartItem.Amount++;
				}
				else
				{
					existingFavourite.FavouritesItems.Add(new FavouritesItem
					{
						Amount = 1,
						Product = product,
						Favourites = existingFavourite
					});
				}
			}
			_dataBaseContext.SaveChanges();
		}

		public void Delete(Guid productId, string userId)
		{
			var existingFavourite = TryGetByUserId(userId);

			var existingFavouriteCartItem = existingFavourite?.FavouritesItems?.FirstOrDefault(x => x.Product.Id == productId);
			if (existingFavouriteCartItem == null)
			{
				return;
			}
			existingFavouriteCartItem.Amount--;
			if (existingFavouriteCartItem.Amount == 0)
			{
				existingFavourite.FavouritesItems.Remove(existingFavouriteCartItem);
			}
			_dataBaseContext.SaveChanges();
		}

		public void Clear(string userId)
		{
			var existingFavourite = TryGetByUserId(userId);
			_dataBaseContext.Favourites?.Remove(existingFavourite);
			_dataBaseContext.SaveChanges();
		}
	}
}
