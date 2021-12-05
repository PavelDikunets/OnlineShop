using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using System;
using System.Linq;

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

        public IActionResult Index()
        {
            var products = compareProductStorage.GetAll(Constants.UserId);
            return View(products.Select(x => x.ToProductViewModel()).ToList());
        }

        public IActionResult Add(Guid productId)
        {
            var product = productsStorage.TryGetById(productId);
            compareProductStorage.Add(Constants.UserId, product);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(Guid productId)
        {
            compareProductStorage.Remove(Constants.UserId, productId);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Clear(string userId)
        {
            compareProductStorage.Clear(Constants.UserId);
            return RedirectToAction(nameof(Index));
        }
    }
}