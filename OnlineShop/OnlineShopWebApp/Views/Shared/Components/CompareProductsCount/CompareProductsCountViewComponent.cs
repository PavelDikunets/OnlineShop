using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Views.Shared.Components.CartToViewModel
{
    public class CompareProductsCountViewComponent : ViewComponent
    {
        private readonly ICompareStorage compareStorage;

        public CompareProductsCountViewComponent(ICompareStorage compareStorage)
        {
            this.compareStorage = compareStorage;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var productsCount = await compareStorage.GetAllAsync(Constants.UserId);
            return View("CompareProductsCount", productsCount.Count);
        }
    }
}
