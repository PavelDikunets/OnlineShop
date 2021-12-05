using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        private static int InstanceCounter = 0;
        public int Number { get; set; }
        public UserDeliveryInfo User { get; set; }
        public List<CartItemViewModel> Items { get; set; }
        public DateTime CreateDate = DateTime.Now;
        public string Status { get; set; }
        public decimal Cost
        {
            get
            {
                return Items?.Sum(x => x.Cost) ?? 0;
            }
        }
        public Order()
        {
            Id = Guid.NewGuid();
            Number = InstanceCounter;
            InstanceCounter += 1;
            Status = "Создан";
        }
    }
}