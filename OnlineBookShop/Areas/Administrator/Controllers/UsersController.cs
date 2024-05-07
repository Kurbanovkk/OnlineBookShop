using Microsoft.AspNetCore.Mvc;

namespace OnlineBookShop.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
