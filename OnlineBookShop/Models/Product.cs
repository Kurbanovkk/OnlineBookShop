using System.ComponentModel.DataAnnotations;

namespace OnlineBookShop
{
    public class Product
    {
        private static int _instanceCounter = 0;
        public int Id { get;}
        [Required(ErrorMessage = "Не указано наименование товара")]
        [StringLength(70, MinimumLength = 3, ErrorMessage = "Наименование должно содержать от 3 до 70 символов")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указано описание товара")]
        [StringLength(300, MinimumLength = 1, ErrorMessage = "Описание должно содержать от 1 до 300 символов")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Не указана цена товара")]
        [Range(1, 999_999, ErrorMessage = "Цена товара должна быть в диапазоне 1 - 999 999 р.")]
        public decimal Cost { get; set; }
        [Required(ErrorMessage = "Не указан путь изображения товара")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Путь должен содержать от 1 до 100 символов")]
        public string Link { get; set; }

        public Product(string name, string description, decimal cost, string link)
        {
            Id = ++_instanceCounter;
            Name = name;
            Description = description;
            Cost = cost;
            Link = link;
        }

        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Cost}";
        }
    }
}
