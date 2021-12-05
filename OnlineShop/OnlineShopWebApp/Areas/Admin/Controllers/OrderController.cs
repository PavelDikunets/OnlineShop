using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrdersStorage ordersStorage;

        public OrderController(IOrdersStorage ordersStorage)
        {
            this.ordersStorage = ordersStorage;
        }
        public IActionResult Index()
        {
            var orders = ordersStorage.GetAll();
            return View(Mapping.ToOrderViewModels(orders));
        }
        public IActionResult Details(Guid orderId)
        {
            var order = ordersStorage.TryGetById(orderId);
            return View(Mapping.ToOrderViewModel(order));
        }

        [HttpPost]
        public IActionResult UpdateStatus(Guid orderId, OrderStatusViewModel status)
        {
            ordersStorage.UpdateStatus(orderId, (OrderStatus)(int)status);
            return RedirectToAction(nameof(Index));
        }
    }
}