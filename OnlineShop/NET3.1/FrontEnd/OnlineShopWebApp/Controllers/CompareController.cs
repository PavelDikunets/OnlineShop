using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class CompareController : Controller
    {
        private readonly ICompareStorage compareProductStorage;
        private readonly IProductsStorage productsStorage;
        private readonly IMapper _mapper;

        public CompareController(ICompareStorage compareProductStorage, IProductsStorage productsStorage, IMapper mapper)
        {
            this.compareProductStorage = compareProductStorage;
            this.productsStorage = productsStorage;
            _mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
            var products = await compareProductStorage.GetAllAsync(Constants.UserId);
            var model = _mapper.Map<List<ProductViewModel>>(products);
            return View(model);
        }

        public async Task<ActionResult> AddAsync(Guid productId)
        {
            var product = await productsStorage.TryGetByIdAsync(productId);
            await compareProductStorage.AddAsync(Constants.UserId, product);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> RemoveAsync(Guid productId)
        {
            await compareProductStorage.RemoveAsync(Constants.UserId, productId);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> ClearAsync(string userId)
        {
            await compareProductStorage.ClearAsync(Constants.UserId);
            return RedirectToAction(nameof(Index));
        }
    }
}