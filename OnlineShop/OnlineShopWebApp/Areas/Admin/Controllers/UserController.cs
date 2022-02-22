using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System.Linq;
using System.Threading.Tasks;

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
        public IActionResult Add(UserAccountViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.Login == model.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
                return View(model);
            }
            if (_userManager.FindByNameAsync(model.Login) != null)
            {
                ModelState.AddModelError("", "Такой пользователь уже существует!");
                return View(model);
            }

            User user = new User { Email = model.Login, UserName = model.Login, PhoneNumber = model.PhoneNumber };
            var result = _userManager.CreateAsync(user, model.Password).Result;
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }
        public IActionResult Edit(string login)
        {
            var user = _userManager.FindByNameAsync(login).Result;
            UserAccountViewModel model = new UserAccountViewModel { Login = user.Email, PhoneNumber = user.PhoneNumber, Id = user.Id };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserAccountViewModel model)
        {
            User user = await _userManager.FindByNameAsync(model.Login);
            //Нужно реализовать!
            await _userManager.UpdateAsync(user);
            return View(model);
        }


        public IActionResult Remove(string login)
        {
            var user = _userManager.FindByNameAsync(login).Result;
            _userManager.DeleteAsync(user).Wait();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detail(string login)
        {
            var user = _userManager.FindByNameAsync(login).Result;
            UserAccountViewModel model = new UserAccountViewModel { Login = user.Email, PhoneNumber = user.PhoneNumber, Id = user.Id };
            return View(model);
        }

        public async Task<IActionResult> ChangePassword(string login)
        {
            User user = await _userManager.FindByNameAsync(login);
            if (user == null)
            {
                return NotFound();
            }
            ChangePasswordViewModel model = new ChangePasswordViewModel { Login = user.Email };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(model.Login);
                if (user != null)
                {
                    var _passwordValidator =
                        HttpContext.RequestServices.GetService(typeof(IPasswordValidator<User>)) as IPasswordValidator<User>;
                    var _passwordHasher =
                        HttpContext.RequestServices.GetService(typeof(IPasswordHasher<User>)) as IPasswordHasher<User>;

                    IdentityResult result =
                        await _passwordValidator.ValidateAsync(_userManager, user, model.NewPassword);
                    if (result.Succeeded)
                    {
                        user.PasswordHash = _passwordHasher.HashPassword(user, model.NewPassword);
                        await _userManager.UpdateAsync(user);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Пользователь не найден");
                }
            }
            return View(model);
        }
    }
}