using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using System;

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
            return View(cart);
        }

        public IActionResult Add(Guid productId)
        {
            var product = productsStorage.TryGetById(productId);
           // cartsStorage.Add(product, Constants.UserId);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult DecreaseAmount(Guid productId)
        {
            var product = productsStorage.TryGetById(productId);
            //cartsStorage.DecreaseAmount(product, Constants.UserId);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Clear()
        {
            cartsStorage.Clear(Constants.UserId);
            return RedirectToAction(nameof(Index));
        }
    }
}