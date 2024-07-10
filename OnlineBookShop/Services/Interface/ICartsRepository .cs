namespace OnlineBookShop
{
    public interface ICartsRepository
    {
        public Cart TryGetByUserId(string userId);
        public void Add(ProductViewModel product, string userId);
        public void Delete(Guid productId, string userId);
        void Clear();
    }
}
