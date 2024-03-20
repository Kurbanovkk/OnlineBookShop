namespace OnlineBookShop
{
    public interface IFavouritesRepository
    {
        public Favourites TryGetByUserId(string userId);

        public void Add(Product product, string userId);
        void Clear();
        public void Delete(int productId, string userId);
    }
}
