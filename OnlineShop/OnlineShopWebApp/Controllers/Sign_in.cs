using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class Sign_in : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login(string login, string password, bool remember)
        {
            return RedirectToAction("Index");
        }
    }
}
