using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class ProductController : Controller
    {
        private readonly IProductsStorage productsStorage;
        private readonly IMapper _mapper;

        public ProductController(IProductsStorage productsStorage, IMapper mapper)
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

        public async Task<ActionResult> EditAsync(Guid productId)
        {
            var product = await productsStorage.TryGetByIdAsync(productId);
            var model = _mapper.Map<ProductViewModel>(product);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> EditAsync(ProductViewModel model)
        {
            var product = _mapper.Map<Product>(model);
            await productsStorage.UpdateAsync(product);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> RemoveAsync(Guid productId)
        {
            await productsStorage.RemoveAsync(productId);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var product = _mapper.Map<Product>(model);
            await productsStorage.AddAsync(product);
            return RedirectToAction(nameof(Index));
        }
    }
}