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
            DateTime Time = DateTime.Now;
            if (Time.Hour >= 0 && Time.Hour < 6)
            {
                return "Доброй ночи";
            }
            if (Time.Hour >= 6 && Time.Hour < 12)
            {
                return "Доброе утро";
            }
            if (Time.Hour >= 12 && Time.Hour < 18)
            {
                return "Добрый день";
            }
            else return "Добрый вечер";
        }
    }
}
