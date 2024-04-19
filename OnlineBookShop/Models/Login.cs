using System.ComponentModel.DataAnnotations;

namespace OnlineBookShop.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Не указано имя пользователя")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }
        public bool rememberMe { get; set; }

    }
}
