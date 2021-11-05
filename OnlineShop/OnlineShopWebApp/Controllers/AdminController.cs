using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductsStorage productsStorage;

        public AdminController(IProductsStorage productsStorage)
        {
            this.productsStorage = productsStorage;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Orders()
        {
            return View();
        }
        public IActionResult Users()
        {
            return View();
        }
        public IActionResult Roles()
        {
            return View();
        }
        public IActionResult Products()
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
            var products = productsStorage.GetAll();
            var product = productsStorage.TryGetById(editedProduct.Id);
            products.Remove(product);
            products.Add(editedProduct);
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