using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class SearchController : Controller
    {
        private readonly IProductsStorage productsStorage;

        public SearchController(IProductsStorage productsStorage)
        {
            this.productsStorage = productsStorage;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string searchRequest)
        {
            var searchResult = productsStorage.Search(searchRequest);
            return View(nameof(Index), searchResult.Select(x => x.ToProductViewModel()).ToList());
        }
    }
}
