using System.ComponentModel.DataAnnotations;

namespace OnlineBookShop
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "Не указан Логин")]
        [StringLength(21, MinimumLength =2,ErrorMessage ="Логин должен содержать от 2х до21 символов")]
        [EmailAddress(ErrorMessage ="Введите действительную почту")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Введите номер тлефона")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage ="Введите пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Не указан пароль для подтверждения")]
        [Compare("Password", ErrorMessage ="Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
