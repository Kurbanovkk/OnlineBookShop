
namespace OnlineBookShop
{
    public class InMemoryProductsRepository : IProductsRepository
    {
        private List<Product> _products = new List<Product>()
            {
                new Product("Преступление и наказание",
                    "Преступление и наказание» — самый известный роман Фёдора Михайловича Достоевского.",
                    700,
                    "/ImagesForProducts/PrestAndNak.jpg"),
                new Product("Мастер и Маргарита",
                    "Роман советского периода, написанный русским писателем и драматургом Михаилом Булгаковым",
                    650,
                    "/ImagesForProducts/MastAndMarg.jpg"),
                new Product("Анна Каренина",
                    "Роман Льва Толстого, опубликованный в 1877 году",
                    750,
                    "/ImagesForProducts/AnnaKarenina.jpg"),
                new Product("Война и мир",
                    "Произведение Льва Николаевича Толстого, эпическая история, охватывающая период с 1805 по 1812 годы",
                    900,
                    "/ImagesForProducts/WarAmdPeace.jpg"),
                new Product("Бесы",
                    "«Бесы» — шестой роман Фёдора Михайловича Достоевского, изданный в 1871–1872 годах.",
                    730,
                    "/ImagesForProducts/Bes.jpg"),
                new Product("Горе от ума",
                    "«Горе от ума» – пьеса, в которой рассказывается история Чацкого, молодого интеллигента, который возвращается в московское общество после пятилетнего отсутствия.",
                    540,
                    "/ImagesForProducts/Gore.jpg")
            };

        public void AddProducts(string name, Product product)
        {
            var products = _products.FirstOrDefault(name => name.Name.ToLower().Equals(name));
            if (product == null) 
            { 
                _products.Add(product);
            }
        }

        public void Del(int id)
        {
            var product = TryGetById(id);
            _products.Remove(product);
        }

        public List<Product> GetProducts()
        {
            return _products;
        }

        public Product TryGetById(int id)
        {
            return _products.FirstOrDefault(product => product.Id == id);
        }
    }
}
