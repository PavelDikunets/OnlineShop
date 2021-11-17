using Microsoft.AspNetCore.Mvc;
using System;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrdersController : Controller
    {
        private readonly IOrdersStorage ordersStorage;

        public OrdersController(IProductsStorage productsStorage, IOrdersStorage ordersStorage, IRolesStorage rolesStorage)
        {
            this.ordersStorage = ordersStorage;
        }
        public IActionResult Index()
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
    }
}