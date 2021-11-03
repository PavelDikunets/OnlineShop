using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class CompareController : Controller
    {
        private readonly IProductsStorage productsStorage;

        public CompareController(IProductsStorage productsStorage)
        {
            this.productsStorage = productsStorage;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add(int productId)
        {
            var product = productsStorage.TryGetById(productId);
            return RedirectToAction("Index");
        }
    }
}
