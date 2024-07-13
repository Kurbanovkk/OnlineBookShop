namespace OnlineBookShop
{
    public interface IFavouritesRepository
    {
        public Favourites TryGetByUserId(string userId);

        public void Add(ProductViewModel product, string userId);
        void Clear();
        public void Delete(Guid productId, string userId);
    }
}
