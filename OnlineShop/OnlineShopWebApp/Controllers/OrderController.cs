using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Check_out()
        {
            var currentCart = cartsStorage.TryGetByUserId(Constants.UserId);
            ordersStorage.Add(currentCart);
            cartsStorage.Clear(Constants.UserId);
            return View();
        }
    }
}