using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class StartController : Controller
    {
        public string Hello()
        {
            var currentTime = DateTime.Now.Hour;
            if (currentTime < 6)
            {
                return "Доброй ночи";
            }
            if (currentTime < 12)
            {
                return "Доброе утро";
            }
            if (currentTime < 18)
            {
                return "Добрый день";
            }
            return "Добрый вечер";
        }
    }
}
