﻿using System.ComponentModel.DataAnnotations;

namespace OnlineBookShop.Db.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public string Link { get; set; }
        public List<CartItem> CartItems { get; set; }

        public Product() 
        {
            CartItems = new List<CartItem>();
        }
    }
}
