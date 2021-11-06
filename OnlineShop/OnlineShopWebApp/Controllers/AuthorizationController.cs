using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AuthorizationController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserLoginInfo userLoginInfo)
        {
            if (ModelState.IsValid)
            {
                return View("SuccessfulLogin");
            }
            return View(userLoginInfo);
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(UserRegistrationInfo userRegistrationInfo)
        {
            if (ModelState.IsValid)
            {
                return View("SuccessfulRegistration");
            }
            return View(userRegistrationInfo);
        }
    }
}
