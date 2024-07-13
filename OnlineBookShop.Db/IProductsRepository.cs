using OnlineShop.Db.Models;

namespace OnlineShop.Db;

public interface IProductsRepository
{
	public void AddProducts(Product product);

	void Del(Guid id);
    public List<Product> GetProducts();
    public Product TryGetById(Guid id);
}
