namespace OnlineBookShop
{
    public class InMemoryFavouritesRepository : IFavouritesRepository
    {
        private List<Favourites> _favourites = new List<Favourites>();

        public Favourites TryGetByUserId(string userId)
        {
            return _favourites.FirstOrDefault(x => x.UserId == userId);
        }

        public void Add(Product product, string userId)
        {
            var existingFavourites = TryGetByUserId(userId);

            if (existingFavourites == null)
            {
                var newFavourites = new Favourites
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    FavouritesItems = new List<FavouritesItem>
                    {
                        new FavouritesItem
                        {
                            Id = Guid.NewGuid(),
                            Amount = 1,
                            Product = product
                        }
                    }
                };
                _favourites.Add(newFavourites);
            }

            else
            {
                var existingFavoritesItem = existingFavourites?.FavouritesItems?.FirstOrDefault(x => x.Product.Id == product.Id);

                if (existingFavoritesItem != null)
                {
                    existingFavoritesItem.Amount++;
                }
                else
                {
                    existingFavourites.FavouritesItems.Add(new FavouritesItem
                    {
                        Id = Guid.NewGuid(),
                        Amount = 1,
                        Product = product
                    });
                }
            }
        }
        public void Clear()
        {
            _favourites.Clear();
        }

        public void Delete(int productId, string userId)
        {
            var existingFavourites = TryGetByUserId(userId);
            var existingFavouritesItem = existingFavourites?.FavouritesItems?.FirstOrDefault(x => x.Product.Id == productId);
                existingFavourites.FavouritesItems.Remove(existingFavouritesItem);

            if (existingFavourites.FavouritesItems.Count == 0)
            {
                _favourites.Clear();
            }

        }
    }
}
