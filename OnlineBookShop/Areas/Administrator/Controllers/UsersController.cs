using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using OnlineBookShop;

namespace OnlineBookShop.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class UsersController : Controller
    {
        private readonly IRolesRepository _rolesRepository;
        private readonly IUsersRepository _usersRepository;

        public UsersController(IRolesRepository rolesRepository, IUsersRepository usersRepository)
        {
            _rolesRepository = rolesRepository;
            _usersRepository = usersRepository;
        }
        public IActionResult Index()
        {
            var users = _usersRepository.GetUsers();
            return View(users);
        }

        public IActionResult UserDetails(Guid id)
        {
            var user = _usersRepository.TryGetById(id);
            return View(user);
        }

        public IActionResult AddUser() { return View(); }

        [HttpPost]
        public IActionResult AddUser(RegisterUser registerUser)
        {
            var users = _usersRepository.TryGetByName(registerUser.UserName);
            if (users != null)
                ModelState.AddModelError("", "Такой пользователь уже есть!!!");
            if (registerUser.UserName == registerUser.Password)
            {
                ModelState.AddModelError("", "Имя пользователя и пароль не должны совпадать");
                return View(registerUser);
            }
            if (!ModelState.IsValid)
                return View(registerUser);
            _usersRepository.AddUser(new User(registerUser.UserName, registerUser.Password, registerUser.Name, registerUser.PhoneNumber));
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Del(Guid id)
        {
            _usersRepository.Del(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditUser(Guid id)
        {
            var user = _usersRepository.TryGetById(id);
            var editUser = new EditUser();
            editUser.UserName = user.UserName;
            editUser.Name = user.Name;
            editUser.PhoneNumber = user.PhoneNumber;
            ViewData["id"] = id;
            return View(editUser);
        }

        [HttpPost]
        public IActionResult EditUser(EditUser editUser, Guid id)
        {
            if(!ModelState.IsValid) { return View(editUser); }

            _usersRepository.Edit(editUser, id);
            return RedirectToAction(nameof(Index));
        }
    }
}
