using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public UserDeliveryInfoViewModel UserDeliveryInfo { get; set; }
        public List<CartItemViewModel> Items { get; set; }
        public DateTime CreateDateTime = DateTime.Now;
        public OrderStatusViewModel Status { get; set; }
        public decimal Cost
        {
            get
            {
                return Items?.Sum(x => x.Cost) ?? 0;
            }
        }
        public OrderViewModel()
        {
            Status = OrderStatusViewModel.Created;
        }
    }
}