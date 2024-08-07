using OnlineBookShop.Db.Models;

namespace OnlineBookShop.Db
{
public interface IProductsRepository
{
	public void AddProducts(Product product);

	void Del(Guid id);
    public List<Product> GetProducts();
    public Product TryGetById(Guid id);
}
}