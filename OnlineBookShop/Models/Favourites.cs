namespace OnlineBookShop
{
    public class Favourites
    {
        public Guid Id { get; set; }

        public string? UserId { get; set; }

        public List<FavouritesItem>? FavouritesItems { get; set; }

        public decimal Amount
        {
            get
            {
                return FavouritesItems?.Sum(x => x.Amount) ?? 0;
            }
        }
    }
}
