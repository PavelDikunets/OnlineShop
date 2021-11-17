using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Areas
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}