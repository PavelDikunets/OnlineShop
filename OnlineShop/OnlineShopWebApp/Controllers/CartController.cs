using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using System;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductsStorage productsStorage;
        private readonly ICartsStorage cartsStorage;

        public CartController(IProductsStorage productsStorage, ICartsStorage cartsStorage)
        {
            this.productsStorage = productsStorage;
            this.cartsStorage = cartsStorage;
        }
        public async Task<ActionResult> Index()
        {
            var cart = await cartsStorage.TryGetByUserIdAsync(Constants.UserId);
            return View(cart.ToCartViewModel());
        }

        public async Task<ActionResult> AddAsync(Guid productId)
        {
            var product = await productsStorage.TryGetByIdAsync(productId);
            await cartsStorage.AddAsync(product, Constants.UserId);
            return RedirectToAction(nameof(Index));
        }
        public async Task<ActionResult> DecreaseAmountAsync(Guid productId)
        {
            var product = await productsStorage.TryGetByIdAsync(productId);
            await cartsStorage.DecreaseAmountAsync(product, Constants.UserId);
            return RedirectToAction(nameof(Index));
        }
        public async Task<ActionResult> ClearAsync()
        {
            await cartsStorage.ClearAsync(Constants.UserId);
            return RedirectToAction(nameof(Index));
        }
    }
}