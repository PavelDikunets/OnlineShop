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

        public async Task<ActionResult> Index()
        {
            var products = await productsStorage.GetAllAsync();
            return View(products.Select(x => x.ToProductViewModel()).ToList());
        }

        public async Task<ActionResult> EditAsync(Guid productId)
        {
            var product = await productsStorage.TryGetByIdAsync(productId);
            return View(product.ToProductViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> EditAsync(ProductViewModel product)
        {
            var productDb = new Product
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description
            };
            await productsStorage.UpdateAsync(productDb);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> RemoveAsync(Guid productId)
        {
            await productsStorage.RemoveAsync(productId);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(ProductViewModel product)
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
            await productsStorage.AddAsync(productDb);
            return RedirectToAction(nameof(Index));
        }
    }
}