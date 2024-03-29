﻿using System.ComponentModel.DataAnnotations;

namespace OnlineShop.WebApp.Models
{
    public enum OrderStatusViewModel
    {
        [Display(Name = "Создан")]
        Created,

        [Display(Name = "Обработан")]
        Processed,

        [Display(Name = "В пути")]
        Delivering,

        [Display(Name = "Отправлен")]
        Delivered,

        [Display(Name = "Отменен")]
        Canceled
    }
}