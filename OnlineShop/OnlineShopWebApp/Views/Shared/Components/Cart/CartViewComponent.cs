using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartsStorage cartsStorage;

        public CartViewComponent(ICartsStorage cartsStorage)
        {
            this.cartsStorage = cartsStorage;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cart = await cartsStorage.TryGetByUserIdAsync(Constants.UserId);
            var cartViewModel = cart.ToCartViewModel();
            var productCounts = cartViewModel?.Amount ?? 0;
            return View("Cart", productCounts);
        }
    }
}
