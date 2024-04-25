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
        public IActionResult Index(Login user)
        {
            if (ModelState.IsValid)
            {
                return Redirect("/Home/Index");
            }
            return View(user);
        }
        
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterUser(RegisterUser registerUser) 
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
