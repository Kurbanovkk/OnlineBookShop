namespace OnlineBookShop.Models
{
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool rememberMe { get; set; }

    }
}
