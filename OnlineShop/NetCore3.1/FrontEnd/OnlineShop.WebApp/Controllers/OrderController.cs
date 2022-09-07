using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.WebApp.Models;
using OnlineShopWebApp;
using System.Threading.Tasks;

namespace OnlineShop.WebApp.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ICartsStorage cartsStorage;
        private readonly IOrdersStorage ordersStorage;
        private readonly IMapper _mapper;

        public OrderController(ICartsStorage cartsStorage, IOrdersStorage ordersStorage, IMapper mapper)
        {
            this.cartsStorage = cartsStorage;
            this.ordersStorage = ordersStorage;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Check_outAsync(UserDeliveryInfoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }
            var currentCart = await cartsStorage.TryGetByUserIdAsync(Constants.UserId);
            var orderDb = new Order
            {
                UserDeliveryInfo = _mapper.Map<UserDeliveryInfo>(model),
                Items = currentCart.Items
            };
            await ordersStorage.AddAsync(orderDb);
            await cartsStorage.ClearAsync(Constants.UserId);
            return View();
        }
    }
}