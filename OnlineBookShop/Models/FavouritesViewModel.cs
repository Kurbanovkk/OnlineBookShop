namespace OnlineBookShop
{
    public class FavouritesViewModel
    {
        public Guid Id { get; set; }

        public string? UserId { get; set; }

        public List<FavouritesItemViewModel>? FavouritesItems { get; set; }

        public decimal Amount
        {
            get
            {
                return FavouritesItems?.Sum(x => x.Amount) ?? 0;
            }
        }
    }
}
