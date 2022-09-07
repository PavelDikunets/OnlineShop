using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using System.Threading.Tasks;

namespace OnlineShop.WebApp.Views.Shared.Components.FavoriteProductsCount
{
    public class FavoriteProductsCountViewComponent : ViewComponent
    {
        private readonly IFavoriteStorage favoriteStorage;

        public FavoriteProductsCountViewComponent(IFavoriteStorage favoriteStorage)
        {
            this.favoriteStorage = favoriteStorage;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var productsCount = await favoriteStorage.GetAllAsync(Constants.UserId);
            return View("FavoriteProductsCount", productsCount.Count);
        }
    }
}
