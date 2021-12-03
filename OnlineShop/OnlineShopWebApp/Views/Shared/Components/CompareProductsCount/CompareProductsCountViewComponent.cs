using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Views.Shared.Components.Cart
{
    public class CompareProductsCountViewComponent : ViewComponent
    {
        private readonly ICompareStorage compareStorage;

        public CompareProductsCountViewComponent(ICompareStorage compareStorage)
        {
            this.compareStorage = compareStorage;
        }

        public IViewComponentResult Invoke()
        {
            var productsCount = compareStorage.GetAll(Constants.UserId).Count;
            return View("CompareProductsCount", productsCount);
        }
    }
}
