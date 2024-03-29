﻿namespace OnlineBookShop
{
    public class Cart
    {
        public Guid Id { get; set; }

        public string? UserId { get; set; }

        public List<CartItem>? CartItems { get; set; }

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
