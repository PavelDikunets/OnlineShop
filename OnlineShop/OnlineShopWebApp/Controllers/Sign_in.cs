using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class Sign_in : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
