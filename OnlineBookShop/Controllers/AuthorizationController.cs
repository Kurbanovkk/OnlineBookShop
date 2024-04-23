using Microsoft.AspNetCore.Mvc;

namespace OnlineBookShop.Controllers
{
    public class AuthorizationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Enter(Login user)
        {
            return Redirect("/Home/Index");
        }
        
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewUser(RegisterUser registerUser) 
        {
            return Redirect("/Home/Index");
        }
    }
}
