using OnlineBookShop.Db.Models;

namespace OnlineBookShop.Helpers
{
	public static class Mapping
	{
		public static List<ProductViewModel> ToProductViewModels(List<Product> products)
		{
			var productsViewModels = new List<ProductViewModel>();
			foreach (var product in products)
			{
				productsViewModels.Add(ToProductViewModel(product));
			}
			return productsViewModels;
		}

		public static ProductViewModel ToProductViewModel(Product product)
		{
			return new ProductViewModel
			{
				Id = product.Id,
				Name = product.Name,
				Cost = product.Cost,
				Description = product.Description,
				Link = product.Link,
			};
		}

		public static CartViewModel ToCartViewModel(Cart cart)
		{
			if (cart == null) return null;

			return new CartViewModel
				{
					Id = cart.Id,
					UserId = cart.UserId,
					CartItems = ToCartItemViewModels(cart.CartItems)
				};
		}
		public static FavouritesViewModel ToFavouritesViewModel(Favourites favourites)
		{
			if (favourites == null) return null;

			return new FavouritesViewModel
			{
				Id = favourites.Id,
				UserId = favourites.UserId,
				FavouritesItems = ToFavouritesItemViewModels(favourites.FavouritesItems)
			};
		}
		public static List<CartItemViewModel> ToCartItemViewModels(List<CartItem> cartDbitems)
		{
			if (cartDbitems == null) return null;
			var cartItems = new List<CartItemViewModel>();
			foreach (var cartDbitem in cartDbitems)
			{
				var cartItem = new CartItemViewModel
				{
					Id = cartDbitem.Id,
					Amount = cartDbitem.Amount,
					Product = ToProductViewModel(cartDbitem.Product)
				};
				cartItems.Add(cartItem);
			}
			return cartItems;
		}


		public static List<FavouritesItemViewModel> ToFavouritesItemViewModels(List<FavouritesItem> favouritesDbItems)
		{
			if (favouritesDbItems == null) return null;
			var favouritesItems = new List<FavouritesItemViewModel>();
			foreach (var favouritesDbItem in favouritesDbItems)
			{
				var favouriteItem = new FavouritesItemViewModel
				{
					Id = favouritesDbItem.Id,
					Amount = favouritesDbItem.Amount,
					Product = ToProductViewModel(favouritesDbItem.Product)
				};
				favouritesItems.Add(favouriteItem);
			}
			return favouritesItems;
		}
	}
}
