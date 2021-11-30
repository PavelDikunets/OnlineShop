﻿using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Models
{
    public class FavoriteProduct
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<Product> Products { get; set; }
    }
}
