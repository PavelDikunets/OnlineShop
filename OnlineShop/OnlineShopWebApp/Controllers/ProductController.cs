using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using System;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsStorage productsStorage;

        public ProductController(IProductsStorage productsStorage)
        {
            this.productsStorage = productsStorage;
        }
        public async Task<IActionResult> Index(Guid productId)
        {
            var product = await productsStorage.TryGetByIdAsync(productId);
            return View(product.ToProductViewModel());
        }
    }
}