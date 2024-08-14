namespace OnlineBookShop.Db.Models
{
    public class Favourites
    {
        public Guid Id { get; set; }

        public string? UserId { get; set; }

        public List<FavouritesItem>? FavouritesItems { get; set; }
        public Favourites() 
            {
                FavouritesItems = new List<FavouritesItem> { };
	        }

    }
}
