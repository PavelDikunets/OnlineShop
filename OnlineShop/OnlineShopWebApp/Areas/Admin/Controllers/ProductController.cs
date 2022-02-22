using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class ProductController : Controller
    {
        private readonly IProductsStorage productsStorage;

        public ProductController(IProductsStorage productsStorage)
        {
            this.productsStorage = productsStorage;
        }

        public async Task<IActionResult> Index()
        {
            var products = await productsStorage.GetAllAsync();
            return View(products.Select(x => x.ToProductViewModel()).ToList());
        }

        public async Task<IActionResult> EditAsync(Guid productId)
        {
            var product = await productsStorage.TryGetByIdAsync(productId);
            return View(product.ToProductViewModel());
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel product)
        {
            var productDb = new Product
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description
            };
            productsStorage.UpdateAsync(productDb);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(Guid productId)
        {
            productsStorage.RemoveAsync(productId);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            var productDb = new Product
            {
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description
            };
            productsStorage.AddAsync(productDb);
            return RedirectToAction(nameof(Index));
        }
    }
}