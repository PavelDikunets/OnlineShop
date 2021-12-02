using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Views.Shared.Components.Cart
{
    public class FavoriteProductsCountViewComponent : ViewComponent
    {
        private readonly IFavoriteStorage favoriteStorage;

        public FavoriteProductsCountViewComponent(IFavoriteStorage favoriteStorage)
        {
            this.favoriteStorage = favoriteStorage;
        }

        public IViewComponentResult Invoke()
        {
            var productsCount = favoriteStorage.GetAll(Constants.UserId).Count;
            return View("FavoriteProductsCount", productsCount);
        }
    }
}
