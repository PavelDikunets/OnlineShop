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
        public IActionResult Check_out(UserDeliveryInfo user)
        {
            if (ModelState.IsValid)
            {
                var currentCart = cartsStorage.TryGetByUserId(Constants.UserId);
                var order = new Order
                {
                    User = user,
                    Items = currentCart.Items
                };
                ordersStorage.Add(order);
                cartsStorage.Clear(Constants.UserId);
                return View();

            }
            return View(user);
        }
    }
}