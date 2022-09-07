using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.WebApp.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly IFavoriteStorage favoriteProductStorage;
        private readonly IProductsStorage productsStorage;
        private readonly IMapper _mapper;

        public FavoriteController(IFavoriteStorage favoriteProductStorage, IProductsStorage productsStorage, IMapper mapper)
        {
            this.favoriteProductStorage = favoriteProductStorage;
            this.productsStorage = productsStorage;
            _mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
            var products = await favoriteProductStorage.GetAllAsync(Constants.UserId);
            var model = _mapper.Map<List<ProductViewModel>>(products);
            return View(model);
        }

        public async Task<ActionResult> AddAsync(Guid productId)
        {
            var product = await productsStorage.TryGetByIdAsync(productId);
            await favoriteProductStorage.AddAsync(Constants.UserId, product);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> RemoveAsync(Guid productId)
        {
            await favoriteProductStorage.RemoveAsync(Constants.UserId, productId);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> ClearAsync(string userId)
        {
            await favoriteProductStorage.ClearAsync(Constants.UserId);
            return RedirectToAction(nameof(Index));
        }
    }
}