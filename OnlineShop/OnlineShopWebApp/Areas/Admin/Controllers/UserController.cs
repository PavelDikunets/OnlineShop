using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUsersStorage usersStorage;

        public UserController(IUsersStorage usersStorage)
        {
            this.usersStorage = usersStorage;
        }

        public IActionResult Index()
        {
            var users = usersStorage.GetAll();
            return View(users);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(UserAccount userAccount)
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
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int userId)
        {
            var userAccount = usersStorage.TryGetById(userId);
            return View(userAccount);
        }

        [HttpPost]
        public IActionResult Edit(UserAccount editedAccount)
        {
            usersStorage.Edit(editedAccount);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Remove(int userId)
        {
            usersStorage.Remove(userId);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Detail(int userId)
        {
            var userAccount = usersStorage.TryGetById(userId);
            return View(userAccount);
        }
        public IActionResult ChangePassword(string login)
        {
            var changePassword = new ChangePassword()
            {
                Login = login
            };
            return View(changePassword);
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePassword changePassword)
        {
            if (changePassword.Login == changePassword.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
            }
            if (ModelState.IsValid)
            {
                usersStorage.ChangePassword(changePassword.Login, changePassword.Password);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(ChangePassword));
        }
    }
}