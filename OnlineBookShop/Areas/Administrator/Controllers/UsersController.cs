using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using OnlineBookShop;
using OnlineBookShop.Db;
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
            {
                return View(registerUser);
            }    
                
            _usersRepository.AddUser(new UserViewModel(registerUser.UserName, registerUser.Password, registerUser.Name, registerUser.PhoneNumber));
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
            return View(user);
        }

        [HttpPost]
        public IActionResult EditUser(UserEdit userEdit, Guid id)
        {
            if(!ModelState.IsValid) { return View(userEdit); }

            var currentUser = _usersRepository.TryGetById(id);
            currentUser.UserName = userEdit.UserName;
            currentUser.Name = userEdit.Name;
            currentUser.PhoneNumber = userEdit.PhoneNumber;
            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditPassword(Guid id)
        {
            var user = _usersRepository.TryGetById(id);
            ViewData["id"] = id;
            ViewData["userName"] = user.UserName;
            return View();
        }

        [HttpPost]
        public IActionResult EditPassword(Guid id, string password)
        {
            _usersRepository.ChangePassword(id, password);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditRole(Guid id)
        {
            var user = _usersRepository.TryGetById(id);
            var roles = _rolesRepository.GetAllRoles();
            ViewData["id"] = id;
            ViewData["userName"] = user.UserName;
            ViewData["userRole"] = user.Role.Name;
            return View(roles);
        }

        [HttpPost]
        public IActionResult EditRole(Guid id, string role)
        {
            _usersRepository.ChangeAccess(id, role);
            return RedirectToAction(nameof(Index));
        }
    }
}
