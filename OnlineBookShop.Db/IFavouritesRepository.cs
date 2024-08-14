using OnlineBookShop.Db.Models;
namespace OnlineBookShop.Db
{
    public interface IFavouritesRepository
    {
        public Favourites TryGetByUserId(string userId);

        public void Add(Product product, string userId);
        void Clear(string userId);
        public void Delete(Guid productId, string userId);
    }
}
