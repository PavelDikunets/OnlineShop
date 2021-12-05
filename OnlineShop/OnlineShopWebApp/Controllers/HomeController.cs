using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsStorage productsStorage;

        public HomeController(IProductsStorage productsStorage)
        {
            this.productsStorage = productsStorage;
        }

        public IActionResult Index()
        {
            var products = productsStorage.GetAll();
            return View(products.Select(x => x.ToProductViewModel()).ToList());
        }
    }
}