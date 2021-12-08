using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using System.Collections.Generic;
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

        public IActionResult Index(List<Product> searchResult)
        {
            return View(searchResult);
        }

        [HttpPost]
        public IActionResult Query(string searchRequest)
        {
            var searchResult = productsStorage.Search(searchRequest);
            return View(nameof(Index),searchResult.Select(x => x.ToProductViewModel()).ToList());
        }
    }
}
