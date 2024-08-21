using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using OnlineBookShop.Db;

namespace OnlineBookShop.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IUsersRepository _usersRepository;

        public AuthorizationController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Login user)
        {
            var userAccount = _usersRepository.TryGetByName(user.UserName);
            if (userAccount == null)
            {
                ModelState.AddModelError("", "Пользователь с таким именем не найден. Проверьте имя или зарегистрируйтесь.");
                return View(user);
            }

            
            if (userAccount.Password != user.Password)
            {
                ModelState.AddModelError("", "Неверный пароль");
                return View(user);
            }
            if (user.UserName == user.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны словпадать");
            }
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUser registerUser) 
        {
            var userAccount = _usersRepository.TryGetByName(registerUser.UserName);
            if (userAccount != null)
            {
                ModelState.AddModelError("", "Пользователь с таким именем уже есть.");
                return View(registerUser);
            }
            if (registerUser.UserName == registerUser.Password)
            {
                ModelState.AddModelError("","Логин и пароль не должны словпадать");
            }
            if(ModelState.IsValid)
            {
                _usersRepository.AddUser(new UserViewModel(registerUser.UserName, registerUser.Password, registerUser.Name, registerUser.PhoneNumber));
                return RedirectToAction(nameof(AuthorizationController.Index), "Authorization");
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
