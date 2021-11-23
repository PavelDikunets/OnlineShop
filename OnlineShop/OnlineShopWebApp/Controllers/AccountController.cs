using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersStorage usersStorage;

        public AccountController(IUsersStorage usersStorage)
        {
            this.usersStorage = usersStorage;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserLogin userAccount)
        {
            if (!ModelState.IsValid)
            {
                return View(userAccount);
            }
            var existUserAccount = usersStorage.TryGetByName(userAccount.Login);
            if (userAccount == null)
            {
                ModelState.AddModelError("", "Такого пользователя не существует!");
                return View(userAccount);
            }
            if (existUserAccount.Password != userAccount.Password)
            {
                ModelState.AddModelError("", "Логин и/или пароль неправильные!");
                return View(userAccount);
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(UserAccount userAccount)
        {
            if (!ModelState.IsValid)
            {
                return View(userAccount);
            }
            if (userAccount.Login == userAccount.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
                return View(userAccount);
            }
            if (usersStorage.TryGetByName(userAccount.Login) != null)
            {
                ModelState.AddModelError("", "Такой пользователь уже существует!");
                return View(userAccount);
            }
            usersStorage.Add(userAccount);
            return View("SuccessfulRegistration");
        }
    }
}
