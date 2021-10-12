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
            int Time = DateTime.Now.Hour;
            if (Time < 6)
            {
                return "Доброй ночи";
            }
            if (Time < 12)
            {
                return "Доброе утро";
            }
            if (Time >= 12 && Time < 18)
            {
                return "Добрый день";
            }
            return "Добрый вечер";
        }
    }
}
