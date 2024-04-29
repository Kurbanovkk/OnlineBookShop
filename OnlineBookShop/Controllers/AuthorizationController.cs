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
        public IActionResult Index(Login login)
        {
            if (login.UserName == login.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны словпадать");
            }
            if (ModelState.IsValid)
            {
                return Redirect("/Home/Index");
            }
            return View(login);
        }
        
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUser registerUser) 
        {
            if (registerUser.Email == registerUser.Password)
            {
                ModelState.AddModelError("","Логин и пароль не должны словпадать");
            }
            if(ModelState.IsValid)
            {
                return Redirect("/Home/Index");
            }
            return View(registerUser);
        }
    }
}
