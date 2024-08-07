﻿namespace OnlineBookShop.Db.Models
{
    public interface ICartsRepository
    {
        public Cart TryGetByUserId(string userId);
        public void Add(Product product, string userId);
        public void Delete(Guid productId, string userId);
        void Clear(string userId);
    }
}
