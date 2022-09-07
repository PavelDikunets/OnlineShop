using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.WebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.WebApp.Controllers
{
    public class SearchController : Controller
    {
        private readonly IProductsStorage productsStorage;
        private readonly IMapper _mapper;

        public SearchController(IProductsStorage productsStorage, IMapper mapper)
        {
            this.productsStorage = productsStorage;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(string searchRequest)
        {
            var searchResult = await productsStorage.SearchAsync(searchRequest);
            var models = _mapper.Map<List<ProductViewModel>>(searchResult);
            return View(nameof(Index), models);
        }
    }
}
