using System.ComponentModel.DataAnnotations;

namespace OnlineBookShop
{
    public class UserDeliveryInfo
    {
        [Required(ErrorMessage = "Не указана Почта")]
        [StringLength(21, MinimumLength = 2, ErrorMessage = "Почта должна содержать от 2х до21 символов")]
        [EmailAddress(ErrorMessage = "Введите действительную почту")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Поле ФИО должно быть заполнено")]
        [StringLength(70, MinimumLength = 3, ErrorMessage = "ФИО должно содержать от 3 до 70 символов")]
        //[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Используйте только буквы и пробел")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле Адрес должно быть заполнено")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Поле Адрес должно содержать от 5 до 200 символов")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Поле Телефон должно быть заполнено")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Поле Телефон должно содержать от 5 до 20 символов")]
        [RegularExpression(@"^[\d\+]+$", ErrorMessage = "Используйте только цифры и символ '+'")]
        public string PhoneNumber { get; set; }

        public string Comment { get; set; }
    }
}