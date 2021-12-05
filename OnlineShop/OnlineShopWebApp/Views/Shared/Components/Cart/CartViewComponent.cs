using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartsStorage cartsStorage;

        public CartViewComponent(ICartsStorage cartsStorage)
        {
            this.cartsStorage = cartsStorage;
        }

        public IViewComponentResult Invoke()
        {
            var cart = cartsStorage.TryGetByUserId(Constants.UserId);
            var cartViewModel = cart.ToCartViewModel();
            var productCounts = cartViewModel?.Amount ?? 0;
            return View("Cart", productCounts);
        }
    }
}
