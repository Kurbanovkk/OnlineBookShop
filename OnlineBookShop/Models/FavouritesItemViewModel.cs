namespace OnlineBookShop
{
    public class FavouritesItemViewModel
    {
        public Guid Id { get; set; }

        public ProductViewModel Product { get; set; }

        public decimal Cost
        {
            get
            {
                return Product.Cost;
            }
        }

        public int Amount { get; set; }
    }
}
