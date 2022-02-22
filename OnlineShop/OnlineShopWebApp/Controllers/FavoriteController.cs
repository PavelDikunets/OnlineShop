using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<ActionResult> Index()
        {
            var products = await favoriteProductStorage.GetAllAsync(Constants.UserId);
            return View(products.Select(x => x.ToProductViewModel()).ToList());
        }

        public async Task<ActionResult> AddAsync(Guid productId)
        {
            var product = await productsStorage.TryGetByIdAsync(productId);
            await favoriteProductStorage.AddAsync(Constants.UserId, product);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> RemoveAsync(Guid productId)
        {
            await favoriteProductStorage.RemoveAsync(Constants.UserId, productId);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> ClearAsync(string userId)
        {
            await favoriteProductStorage.ClearAsync(Constants.UserId);
            return RedirectToAction(nameof(Index));
        }
    }
}