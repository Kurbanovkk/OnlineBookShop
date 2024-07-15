using OnlineShop.Db.Models;

namespace OnlineBookShop.Helpers
{
	public static class Mapping
	{
		public static List<ProductViewModel> ToProductViewModels(List<Product> products)
		{
			var productsViewModels = new List<ProductViewModel>();
			foreach (var product in products)
			{
				productsViewModels.Add(ToProductViewModels(product));
			}
			return productsViewModels;
		}

		public static ProductViewModel ToProductViewModels(Product product)
		{
			return new ProductViewModel
			{
				Id = product.Id,
				Name = product.Name,
				Cost = product.Cost,
				Description = product.Description,
				Link = product.Link,
			};
		}
	}
}
