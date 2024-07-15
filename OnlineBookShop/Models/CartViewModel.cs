namespace OnlineBookShop
{
    public class CartViewModel
    {
        public Guid Id { get; set; }

        public string? UserId { get; set; }

        public List<CartItemViewModel>? CartItems { get; set; }

        public decimal Cost 
        { 
            get 
            { 
                return CartItems?.Sum(x => x.Cost) ?? 0;
            } 
        }
        public decimal  Amount
        {
            get
            {
                return CartItems?.Sum(x => x.Amount) ?? 0;
            }
        }
    }
}
