using System.ComponentModel.DataAnnotations;

namespace OnlineBookShop
{
    public class EditUser
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Не указан Логин")]
        [StringLength(21, MinimumLength = 2, ErrorMessage = "Логин должен содержать от 2х до21 символов")]
        [EmailAddress(ErrorMessage = "Введите действительную почту")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(200, MinimumLength = 8, ErrorMessage = "Пароль должен содержать от 8 до 200 символов")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Не указано имя пользователя")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Имя пользователя должно содержать от 1 до 200 символов")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указан телефон пользователя")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Телефон пользователя должно содержать от 5 до 50 символов")]
        public string PhoneNumber { get; set; }
    }
}
