using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class AuthorizationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Sign_in(string login, string password, bool remember)
        {
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Sign_up(string login, string password, string repeatPassword)
        {
            return View();
        }
    }
}
