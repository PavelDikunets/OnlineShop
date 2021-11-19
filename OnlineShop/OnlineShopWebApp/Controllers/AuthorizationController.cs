using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Areas.Admin.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IUsersStorage usersStorage;

        public AuthorizationController(IUsersStorage usersStorage)
        {
            this.usersStorage = usersStorage;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserLoginInfo userLoginInfo)
        {
            if (ModelState.IsValid)
            {
                var users = usersStorage.GetAll();
                foreach (var user in users)
                {
                    if (userLoginInfo.Login == user.Login && userLoginInfo.Password == user.Password)
                    {
                        return View("SuccessfulLogin");
                    }
                    ModelState.AddModelError("", "Логин/пароль неверны");
                }
            }
            return View(userLoginInfo);
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registering(UserRegistrationInfo user)
        {
            if (ModelState.IsValid)
            {
                usersStorage.Add(user);
                return View("SuccessfulRegistration");
            }
            return View(user);
        }
    }
}
