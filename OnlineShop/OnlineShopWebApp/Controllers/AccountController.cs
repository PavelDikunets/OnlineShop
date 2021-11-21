using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Areas.Admin.Models;
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
        public IActionResult Login(UserLogin user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            var userAccount = usersStorage.TryGetByName(user.Login);
            if (userAccount == null)
            {
                ModelState.AddModelError("", "Такого пользователя не существует!");
                return View(user);
            }
            if (userAccount.Password != user.Password)
            {
                ModelState.AddModelError("", "Логин и/или пароль неправильные!");
                return View(user);
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(UserAccount user)
        {
            if (user.Login == user.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
            }
            if (ModelState.IsValid)
            {
                usersStorage.Add(new UserAccount
                {
                    Login = user.Login,
                    Password = user.Password
                });
                return View("SuccessfulRegistration");
            }
            return View(user);
        }
    }
}
