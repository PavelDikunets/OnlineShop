using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login(string returnUrl)
        {
            return View(new Login() { ReturnUrl = returnUrl });
        }
        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(login.UserName, login.Password, login.RememberMe, false).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Логин и/или пароль неправильные!");
                }
            }
            return View(login);
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(UserAccount userAccount)
        {
            if (userAccount.Login == userAccount.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
                return View(userAccount);
            }

            if (ModelState.IsValid)
            {
                User user = new User { Email = userAccount.Login, UserName = userAccount.Login };
                var result = _userManager.CreateAsync(user, userAccount.Password).Result;
                if (result.Succeeded)
                {
                    _signInManager.SignInAsync(user, false).Wait();
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(userAccount);
        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
