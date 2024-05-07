using Microsoft.AspNetCore.Mvc;

namespace OnlineBookShop.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class RolesController : Controller
    {
        private readonly IRolesRepository _rolesRepository;
        public RolesController(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }
        public IActionResult Index()
        {
            var roles = _rolesRepository.GetAllRoles();
            return View(roles);
        }
        public IActionResult AddRoles()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRoles(Roles role)
        {
            var roles = _rolesRepository.GetAllRoles();
            if (roles.FirstOrDefault(r => r.Name == role.Name) != null)
            {
                ModelState.AddModelError("", "Такая роль уже есть");
            }
            if (!ModelState.IsValid)
            {
                return View(role);
            }
            _rolesRepository.Add(role);
            return RedirectToAction("GetRoles");
        }

        [HttpPost]
        public IActionResult DelRoles(string Name)
        {
            var roles = _rolesRepository.GetAllRoles();
            var currentRole = roles.FirstOrDefault(role => role.Name == Name);
            _rolesRepository.Del(currentRole);
            return RedirectToAction("GetRoles");
        }
    }
}
