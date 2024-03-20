namespace OnlineBookShop
{
    public class FavouritesItem
    {
        public Guid Id { get; set; }

        public Product Product { get; set; }

        public decimal Cost
        {
            get
            {
                return Product.Cost;
            }
        }
    }
}
