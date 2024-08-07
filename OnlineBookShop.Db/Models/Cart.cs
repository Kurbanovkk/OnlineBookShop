﻿namespace OnlineBookShop.Db.Models
{
    public class Cart
    {
        public Guid Id { get; set; }

        public string? UserId { get; set; }

        public List<CartItem>? CartItems { get; set; }

        public Cart() 
        {
            CartItems = new List<CartItem>();
        }
    }
}
