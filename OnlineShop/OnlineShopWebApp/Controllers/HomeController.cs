using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsStorage productsStorage;
        private readonly IMapper _mapper;

        public HomeController(IProductsStorage productsStorage, IMapper mapper)
        {
            this.productsStorage = productsStorage;
            _mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
            var products = await productsStorage.GetAllAsync();
            var model = _mapper.Map<List<ProductViewModel>>(products);
            return View(model);
        }
    }
}