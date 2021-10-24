using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductsStorage productsStorage;

        public CartController(ProductsStorage productsStorage)
        {
            this.productsStorage = productsStorage;
        }
        public IActionResult Index()
        {
            var cart = CartsStorage.TryGetByUserId(Constants.UserId);
            return View(cart);
        }

        public IActionResult Add(int productId)
        {
            var product = productsStorage.TryGetById(productId);
            CartsStorage.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}