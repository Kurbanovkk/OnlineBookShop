
using OnlineBookShop.Db.Models;
using OnlineBookShop.Db;

namespace OnlineBookShop.Db
{
    public class ProductsDbRepository : IProductsRepository
    {
        private readonly DatabaseContext _dataBaseContext;

        public ProductsDbRepository(DatabaseContext databaseContext)
        {
            _dataBaseContext = databaseContext;
        }
        //private List<Product> _products = new List<Product>()
        //    {
        //        new Product("Преступление и наказание",
        //            "Преступление и наказание» — самый известный роман Фёдора Михайловича Достоевского.",
        //            700,
        //            "/ImagesForProducts/PrestAndNak.jpg"),
        //        new Product("Мастер и Маргарита",
        //            "Роман советского периода, написанный русским писателем и драматургом Михаилом Булгаковым",
        //            650,
        //            "/ImagesForProducts/MastAndMarg.jpg"),
        //        new Product("Анна Каренина",
        //            "Роман Льва Толстого, опубликованный в 1877 году",
        //            750,
        //            "/ImagesForProducts/AnnaKarenina.jpg"),
        //        new Product("Война и мир",
        //            "Произведение Льва Николаевича Толстого, эпическая история, охватывающая период с 1805 по 1812 годы",
        //            900,
        //            "/ImagesForProducts/WarAmdPeace.jpg"),
        //        new Product("Бесы",
        //            "«Бесы» — шестой роман Фёдора Михайловича Достоевского, изданный в 1871–1872 годах.",
        //            730,
        //            "/ImagesForProducts/Bes.jpg"),
        //        new Product("Горе от ума",
        //            "«Горе от ума» – пьеса, в которой рассказывается история Чацкого, молодого интеллигента, который возвращается в московское общество после пятилетнего отсутствия.",
        //            540,
        //            "/ImagesForProducts/Gore.jpg")
        //    };

        public void AddProducts(Product product)
        {
				_dataBaseContext.Products.Add(product);
                _dataBaseContext.SaveChanges();
        }

        public void Del(Guid id)
        {
            var product = TryGetById(id);
			_dataBaseContext.Products.Remove(product);
			_dataBaseContext.SaveChanges();
		}

        public List<Product> GetProducts()
        {
            return _dataBaseContext.Products.ToList();
        }

        public Product TryGetById(Guid id)
        {
            return _dataBaseContext.Products.FirstOrDefault(product => product.Id == id);
        }
    }
}
