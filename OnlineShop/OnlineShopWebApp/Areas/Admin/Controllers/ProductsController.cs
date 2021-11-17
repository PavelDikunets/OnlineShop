using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductsStorage productsStorage;

        public ProductsController(IProductsStorage productsStorage)
        {
            this.productsStorage = productsStorage;
        }

        public IActionResult Index()
        {
            var products = productsStorage.GetAll();
            return View(products);
        }
        public IActionResult EditProduct(int id)
        {
            var product = productsStorage.TryGetById(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult SaveEditedProduct(Product editedProduct)
        {
            productsStorage.Update(editedProduct);
            return RedirectToAction("Products");
        }
        public IActionResult RemoveProduct(int id)
        {
            productsStorage.Remove(id);
            return RedirectToAction("Products");
        }
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewProduct(Product product)
        {
            productsStorage.Add(product);
            return RedirectToAction("Products");
        }
    }
}