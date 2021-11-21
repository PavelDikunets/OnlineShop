using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductsStorage productsStorage;

        public ProductController(IProductsStorage productsStorage)
        {
            this.productsStorage = productsStorage;
        }

        public IActionResult Index()
        {
            var products = productsStorage.GetAll();
            return View(products);
        }
        public IActionResult Edit(int productId)
        {
            var product = productsStorage.TryGetById(productId);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product editedProduct)
        {
            productsStorage.Update(editedProduct);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Remove(int productId)
        {
            productsStorage.Remove(productId);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Product product)
        {
            productsStorage.Add(product);
            return RedirectToAction(nameof(Index));
        }
    }
}