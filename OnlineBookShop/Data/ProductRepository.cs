using OnlineBookShop.Models;

namespace OnlineBookShop.Data
{
    public class ProductRepository
    {
        private static List<Product> products = new List<Product>()
            {
                new Product("Преступление и наказание", "Преступление и наказание» — самый известный роман Фёдора Михайловича Достоевского.", 700),
                new Product("Мастер и Маргарита", "Роман советского периода, написанный русским писателем и драматургом Михаилом Булгаковым", 650),
                new Product("Анна Каренина", "Роман Льва Толстого, опубликованный в 1877 году", 750),
                new Product("Война и мир", "Произведение Льва Николаевича Толстого, эпическая история, охватывающая период с 1805 по 1812 годы", 900)
            };

        public List<Product> GetProducts()
        {
            return products;
        }

        public Product TryGetById(int id)
        {
            return products.FirstOrDefault(product => product.Id == id);
        }
    }
}
