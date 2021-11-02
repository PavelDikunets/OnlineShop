using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartsStorage cartsStorage;
        private readonly IOrdersStorage ordersStorage;

        public OrderController(ICartsStorage cartsStorage, IOrdersStorage ordersStorage)
        {
            this.cartsStorage = cartsStorage;
            this.ordersStorage = ordersStorage;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Check_out(Order order)
        {
            var currentCart = cartsStorage.TryGetByUserId(Constants.UserId);
            order.Cart = currentCart;
            ordersStorage.Add(order);
            cartsStorage.Clear(Constants.UserId);
            return View();
        }
    }
}