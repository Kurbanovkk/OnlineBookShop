
namespace OnlineBookShop.Db.Models
{
    public class FavouritesItem
    {
        public Guid Id { get; set; }
		public Product Product { get; set; }
		public Favourites Favourites { get; set; }
		public int Amount { get; set; }

	}
}
