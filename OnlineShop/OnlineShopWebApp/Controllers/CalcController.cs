using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class CalcController : Controller
    {
        public string Index(double a, double b, string c)
        {
            if (!string.IsNullOrEmpty(c))
            {
                switch (c)
                {
                    case "+":
                        return $"{a} + {b} = {a + b}";
                    case "-":
                        return $"{a} - {b} = {a - b}";
                    case "*":
                        return $"{a} * {b} = {a * b}";
                    case "/":
                        if (b == 0) return $"На ноль делить нелья!";
                        return $"{a} / {b} = {a / b}";
                    default:
                        return "Неверная операция!\nДоступные операции:\n+ сложение\n- вычитание\n* умножение\n/ деление";
                }
            }
            else return $"{a} + {b} = {a + b}";
        }
    }
}
