using Microsoft.AspNetCore.Mvc;

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

        public IActionResult UserDetails(Guid userId)
        {
            var user = _usersRepository.TryGetById(userId);
            return View(user);
        }
    }
}
