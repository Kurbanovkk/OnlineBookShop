using System.ComponentModel.DataAnnotations;

namespace OnlineBookShop
{
    public class Login
    {
        [Required(ErrorMessage = "Не указан Логин")]
        [StringLength(21, MinimumLength = 2, ErrorMessage = "Логин должен содержать от 2х до21 символов")]
        [EmailAddress(ErrorMessage = "Введите действительную почту")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }
        public bool rememberMe { get; set; }

    }
}
