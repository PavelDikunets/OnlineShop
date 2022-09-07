using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.WebApp.Models;
using System.Threading.Tasks;

namespace OnlineShop.WebApp.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartsStorage cartsStorage;
        private readonly IMapper _mapper;

        public CartViewComponent(ICartsStorage cartsStorage, IMapper mapper)
        {
            this.cartsStorage = cartsStorage;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cart = await cartsStorage.TryGetByUserIdAsync(Constants.UserId);
            var cartModel = _mapper.Map<CartViewModel>(cart);
            var productCounts = cartModel?.Amount ?? 0;
            return View("Cart", productCounts);
        }
    }
}
