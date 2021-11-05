using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Views.Shared.Components.Admin
{
    public class AdminViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("Admin");
        }
    }
}
