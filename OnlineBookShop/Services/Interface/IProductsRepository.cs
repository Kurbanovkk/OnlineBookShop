namespace OnlineBookShop
{
    public interface IProductsRepository
    {
        public List<Product> GetProducts();
        public Product TryGetById(int id);
    }
}
