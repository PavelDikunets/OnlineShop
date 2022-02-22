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
        public IActionResult Index()
        {
            var cart = cartsStorage.TryGetByUserId(Constants.UserId);
            return View(cart.ToCartViewModel());
        }

        public async Task<IActionResult> AddAsync(Guid productId)
        {
            var product = await productsStorage.TryGetByIdAsync(productId);
            cartsStorage.Add(product, Constants.UserId);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DecreaseAmountAsync(Guid productId)
        {
            var product = await productsStorage.TryGetByIdAsync(productId);
            cartsStorage.DecreaseAmount(product, Constants.UserId);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Clear()
        {
            cartsStorage.Clear(Constants.UserId);
            return RedirectToAction(nameof(Index));
        }
    }
}