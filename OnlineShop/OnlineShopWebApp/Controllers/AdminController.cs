using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Products(int id)
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
        public IActionResult SaveEditedProduct(int id, string name, decimal cost, string description)
        {
            productsStorage.Edit(id, name, cost, description);
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
        public IActionResult AddNewProduct(string name, decimal cost, string description)
        {
            productsStorage.Add(name, cost, description);
            return RedirectToAction("Products");
        }
    }
}