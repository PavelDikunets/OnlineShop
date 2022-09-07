using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.WebApp.Areas.Admin.Models;

namespace OnlineShop.WebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class RoleController : Controller
    {
        private readonly IRolesStorage rolesStorage;

        public RoleController(IRolesStorage rolesStorage)
        {
            this.rolesStorage = rolesStorage;
        }

        public IActionResult Index()
        {
            var roles = rolesStorage.GetAll();
            return View(roles);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Role role)
        {
            if (rolesStorage.TryGetByName(role.Name) != null)
            {
                ModelState.AddModelError("", "Текущая роль уже существует!");
            }
            if (ModelState.IsValid)
            {
                rolesStorage.Add(role);
                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }
        public IActionResult Remove(string roleName)
        {
            rolesStorage.Remove(roleName);
            return RedirectToAction(nameof(Index));
        }
    }
}