using System.ComponentModel.DataAnnotations;

namespace OnlineBookShop.Models
{
    public class ChangePassword
    {
        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(200, MinimumLength = 8, ErrorMessage = "Пароль должен содержать от 8 до 200 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указан пароль для подтверждения")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

    }
}
