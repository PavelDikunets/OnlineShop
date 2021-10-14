﻿namespace OnlineShopWebApp.Controllers
{
        public class Product
        {
            public int Id { get; }
            private string Name { get; set; }
            private decimal Cost { get; set; }
            private string Description { get; set; }
            public Product(int id, string name, decimal cost, string description)
            {
                Id = id;
                Name = name;
                Cost = cost;
                Description = description;
            }
            public string Print()
            {
                return $"{Id}\n{Name}\n{Cost}\n";
            }
            public string PrintAboutProduct()
            {
                return $"{Id}\n{Name}\n{Cost}\n{Description}";
            }
        }
}

