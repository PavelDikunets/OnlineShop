using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using System;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly IFavoriteStorage favoriteProductStorage;
        private readonly IProductsStorage productsStorage;

        public FavoriteController(IFavoriteStorage favoriteProductStorage, IProductsStorage productsStorage)
        {
            this.favoriteProductStorage = favoriteProductStorage;
            this.productsStorage = productsStorage;
        }

        public IActionResult Index()
        {
            var products = favoriteProductStorage.GetAll(Constants.UserId);
            return View(products.Select(x => x.ToProductViewModel()).ToList());
        }

        public IActionResult Add(Guid productId)
        {
            var product = productsStorage.TryGetById(productId);
            favoriteProductStorage.Add(Constants.UserId, product);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(Guid productId)
        {
            favoriteProductStorage.Remove(Constants.UserId, productId);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Clear(string userId)
        {
            favoriteProductStorage.Clear(Constants.UserId);
            return RedirectToAction(nameof(Index));
        }
    }
}