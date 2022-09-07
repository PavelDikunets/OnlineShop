using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.WebApp.Models;
using OnlineShopWebApp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.WebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class OrderController : Controller
    {
        private readonly IOrdersStorage ordersStorage;
        private readonly IMapper _mapper;

        public OrderController(IOrdersStorage ordersStorage, IMapper mapper)
        {
            this.ordersStorage = ordersStorage;
            _mapper = mapper;
        }
        public async Task<ActionResult> Index()
        {
            var orders = await ordersStorage.GetAllAsync();
            var models = _mapper.Map<List<OrderViewModel>>(orders);
            return View(models);
        }
        public async Task<ActionResult> DetailsAsync(Guid orderId)
        {
            var order = await ordersStorage.TryGetByIdAsync(orderId);
            var model = _mapper.Map<OrderViewModel>(order);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateStatusAsync(Guid orderId, OrderStatusViewModel status)
        {
            await ordersStorage.UpdateStatusAsync(orderId, (OrderStatus)(int)status);
            return RedirectToAction(nameof(Index));
        }
    }
}