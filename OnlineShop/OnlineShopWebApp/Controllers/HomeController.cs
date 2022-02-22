using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsStorage productsStorage;

        public HomeController(IProductsStorage productsStorage)
        {
            this.productsStorage = productsStorage;
        }

        public async Task<IActionResult> Index()
        {
            var products = await productsStorage.GetAllAsync();
            return View(products.Select(x => x.ToProductViewModel()).ToList());
        }
    }
}