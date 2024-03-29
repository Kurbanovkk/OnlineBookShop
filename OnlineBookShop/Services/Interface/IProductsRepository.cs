namespace OnlineBookShop
{
    public interface IProductsRepository
    {
        void Del(int id);
        public List<Product> GetProducts();
        public Product TryGetById(int id);
    }
}
