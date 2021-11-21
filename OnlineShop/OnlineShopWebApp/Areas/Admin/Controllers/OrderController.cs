using Microsoft.AspNetCore.Mvc;
using System;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrdersStorage ordersStorage;

        public OrderController(IProductsStorage productsStorage, IOrdersStorage ordersStorage, IRolesStorage rolesStorage)
        {
            this.ordersStorage = ordersStorage;
        }
        public IActionResult Index()
        {
            var orders = ordersStorage.GetAll();
            return View(orders);
        }
        public IActionResult Details(Guid orderId)
        {
            var order = ordersStorage.TryGetByOrderId(orderId);
            return View(order);
        }

        [HttpPost]
        public IActionResult UpdateStatus(Guid orderId, string status)
        {
            ordersStorage.UpdateStatus(orderId, status);
            return RedirectToAction(nameof(Index));
        }
    }
}