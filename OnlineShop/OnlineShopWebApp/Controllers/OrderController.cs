using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
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
        public async Task<ActionResult> Check_outAsync(UserDeliveryInfoViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", user);
            }
            var currentCart = await cartsStorage.TryGetByUserIdAsync(Constants.UserId);
            var orderDb = new Order
            {
                UserDeliveryInfo = user.ToUserDeliveryInfo(),
                Items = currentCart.Items
            };
            await ordersStorage.AddAsync(orderDb);
            await cartsStorage.ClearAsync(Constants.UserId);
            return View();
        }
    }
}