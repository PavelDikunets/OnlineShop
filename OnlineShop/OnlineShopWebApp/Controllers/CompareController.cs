using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class CompareController : Controller
    {
        private readonly ICompareStorage compareProductStorage;
        private readonly IProductsStorage productsStorage;

        public CompareController(ICompareStorage compareProductStorage, IProductsStorage productsStorage)
        {
            this.compareProductStorage = compareProductStorage;
            this.productsStorage = productsStorage;
        }

        public async Task<ActionResult> Index()
        {
            var products = await compareProductStorage.GetAllAsync(Constants.UserId);
            return View(products.Select(x => x.ToProductViewModel()).ToList());
        }

        public async Task<ActionResult> AddAsync(Guid productId)
        {
            var product = await productsStorage.TryGetByIdAsync(productId);
            await compareProductStorage.AddAsync(Constants.UserId, product);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> RemoveAsync(Guid productId)
        {
           await compareProductStorage.RemoveAsync(Constants.UserId, productId);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> ClearAsync(string userId)
        {
           await compareProductStorage.ClearAsync(Constants.UserId);
            return RedirectToAction(nameof(Index));
        }
    }
}