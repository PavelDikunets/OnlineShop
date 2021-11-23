using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Areas.Admin.Models;
using System;

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
        public IActionResult Remove(Guid userId)
        {
            var userAccount = usersStorage.TryGetById(userId);
            usersStorage.Remove(userAccount);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Detail(Guid userId)
        {
            var userAccount = usersStorage.TryGetById(userId);
            return View(userAccount);
        }
    }
}