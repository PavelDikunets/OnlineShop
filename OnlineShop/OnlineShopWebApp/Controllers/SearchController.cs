using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<ActionResult> Index(string searchRequest)
        {
            var searchResult = await productsStorage.SearchAsync(searchRequest);
            return View(nameof(Index), searchResult.Select(x => x.ToProductViewModel()).ToList());
        }
    }
}
