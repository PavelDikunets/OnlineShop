using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductsStorage productsStorage;
        private readonly IOrdersStorage ordersStorage;
        private readonly IRolesStorage rolesStorage;

        public AdminController(IProductsStorage productsStorage, IOrdersStorage ordersStorage, IRolesStorage rolesStorage)
        {
            this.productsStorage = productsStorage;
            this.ordersStorage = ordersStorage;
            this.rolesStorage = rolesStorage;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Orders()
        {
            var orders = ordersStorage.GetAll();
            return View(orders);
        }
        public IActionResult OrderDetails(Guid id)
        {
            var order = ordersStorage.TryGetByOrderId(id);
            return View(order);
        }

        [HttpPost]
        public IActionResult UpdateStatus(Guid orderId, string status)
        {
            ordersStorage.UpdateStatus(orderId, status);
            return RedirectToAction("Orders");
        }
        public IActionResult Users()
        {
            return View();
        }
        public IActionResult Roles()
        {
            var roles = rolesStorage.GetAll();
            return View(roles);
        }
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRole(Role role)
        {
            if (rolesStorage.TryGetByName(role.Name) != null)
            {
                ModelState.AddModelError("", "Текущая роль уже существует!");
            }
            if (ModelState.IsValid)
            {
                rolesStorage.Add(role);
                return RedirectToAction("Roles");
            }
            return View(role);
        }
        public IActionResult RemoveRole(string roleName)
        {
            rolesStorage.Remove(roleName);
            return RedirectToAction("Roles");
        }
        public IActionResult Products()
        {
            var products = productsStorage.GetAll();
            return View(products);
        }
        public IActionResult EditProduct(int id)
        {
            var product = productsStorage.TryGetById(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult SaveEditedProduct(Product editedProduct)
        {
            productsStorage.Update(editedProduct);
            return RedirectToAction("Products");
        }
        public IActionResult RemoveProduct(int id)
        {
            productsStorage.Remove(id);
            return RedirectToAction("Products");
        }
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewProduct(Product product)
        {
            productsStorage.Add(product);
            return RedirectToAction("Products");
        }
    }
}