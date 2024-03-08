

namespace OnlineBookShop
{
    public class ProductsRepository
    {
        private static List<Product> products = new List<Product>()
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
                    900,
                    "/ImagesForProducts/Bes.jpg"),
                new Product("Горе от ума",
                    "«Горе от ума» – пьеса, в которой рассказывается история Чацкого, молодого интеллигента, который возвращается в московское общество после пятилетнего отсутствия.",
                    900,
                    "/ImagesForProducts/Gore.jpg")
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
