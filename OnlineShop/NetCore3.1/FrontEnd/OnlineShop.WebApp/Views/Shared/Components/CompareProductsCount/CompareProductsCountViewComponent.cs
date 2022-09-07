using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using System.Threading.Tasks;

namespace OnlineShop.WebApp.Views.Shared.Components.CompareProductsCount
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
