using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.WebApp.Models;
using System;
using System.Threading.Tasks;

namespace OnlineShop.WebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductsStorage productsStorage;
        private readonly ICartsStorage cartsStorage;
        private readonly IMapper _mapper;

        public CartController(IProductsStorage productsStorage, ICartsStorage cartsStorage, IMapper mapper)
        {
            this.productsStorage = productsStorage;
            this.cartsStorage = cartsStorage;
            _mapper = mapper;
        }
        public async Task<ActionResult> Index()
        {
            var cart = await cartsStorage.TryGetByUserIdAsync(Constants.UserId);
            var model = _mapper.Map<CartViewModel>(cart);
            return View(model);
        }

        public async Task<ActionResult> AddAsync(Guid productId)
        {
            var product = await productsStorage.TryGetByIdAsync(productId);
            await cartsStorage.AddAsync(product, Constants.UserId);
            return RedirectToAction(nameof(Index));
        }
        public async Task<ActionResult> DecreaseAmountAsync(Guid productId)
        {
            var product = await productsStorage.TryGetByIdAsync(productId);
            await cartsStorage.DecreaseAmountAsync(product, Constants.UserId);
            return RedirectToAction(nameof(Index));
        }
        public async Task<ActionResult> ClearAsync()
        {
            await cartsStorage.ClearAsync(Constants.UserId);
            return RedirectToAction(nameof(Index));
        }
    }
}