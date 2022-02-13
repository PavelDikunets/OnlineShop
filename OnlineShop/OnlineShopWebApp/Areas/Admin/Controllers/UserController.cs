using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Controllers;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;
using System.Linq;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users.Select(u => u.ToUserViewModel()).ToList());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(UserAccountViewModel userAccount)
        {
            if (!ModelState.IsValid)
            {
                return View(userAccount);
            }
            //if (userAccount.Login == userAccount.Password)
            //{
            //    ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
            //    return View(userAccount);
            //}
            //if (usersStorage.TryGetByName(userAccount.Login) != null)
            //{
            //    ModelState.AddModelError("", "Такой пользователь уже существует!");
            //    return View(userAccount);
            //}

            User user = new User { Email = userAccount.Login, UserName = userAccount.Login, PhoneNumber = userAccount.PhoneNumber };
            var result = _userManager.CreateAsync(user, userAccount.Password).Result;
            if (result.Succeeded)
            {
                _signInManager.SignInAsync(user, false).Wait();
                RedirectToAction(nameof(UserController.Add), "User");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(userAccount);
        }
        //public IActionResult Edit(Guid userId)
        //{
        //    var userAccount = usersStorage.TryGetById(userId);
        //    return View(userAccount);
        //}

        //[HttpPost]
        //public IActionResult Edit(UserAccountViewModel editedAccount)
        //{
        //    usersStorage.Edit(editedAccount);
        //    return RedirectToAction(nameof(Index));
        //}


        public IActionResult Remove(string login)
        {
            User user = new User { Email = login };
            var result = _userManager.FindByNameAsync(user.Email).Result;
            _userManager.DeleteAsync(result).Wait();
            return RedirectToAction(nameof(Index));
        }

        //[HttpPost]
        //public IActionResult Remove(string login)
        //{
        //    User user = new User { Email = login };
        //    var result = _userManager.FindByNameAsync(user.Email).Result;
        //    _userManager.DeleteAsync(result).Wait();
        //    return RedirectToAction(nameof(Index));
        //}
        public IActionResult Detail(string login)
        {
            var result = _userManager.FindByNameAsync(login).Result;
            UserAccountViewModel userAccount = new UserAccountViewModel { Login = result.Email };
            return View(userAccount);
        }
        //public IActionResult ChangePassword(string login)
        //{
        //    var changePassword = new ChangePassword()
        //    {
        //        Login = login
        //    };
        //    return View(changePassword);
        //}

        //[HttpPost]
        //public IActionResult ChangePassword(ChangePassword changePassword)
        //{
        //    if (changePassword.Login == changePassword.Password)
        //    {
        //        ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        usersStorage.ChangePassword(changePassword.Login, changePassword.Password);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return RedirectToAction(nameof(ChangePassword));
        //}
    }
}