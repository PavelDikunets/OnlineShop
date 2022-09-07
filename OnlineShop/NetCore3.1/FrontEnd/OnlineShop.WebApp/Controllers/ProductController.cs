using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using OnlineShop.WebApp.Models;
using OnlineShop.Db;

namespace OnlineShop.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsStorage productsStorage;
        private readonly IMapper _mapper;

        public ProductController(IProductsStorage productsStorage, IMapper mapper)
        {
            this.productsStorage = productsStorage;
            _mapper = mapper;
        }
        public async Task<ActionResult> Index(Guid productId)
        {
            var product = await productsStorage.TryGetByIdAsync(productId);
            var model = _mapper.Map<ProductViewModel>(product);
            return View(model);
        }
    }
}