using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class Order
    {
        private static int InstanceCounter = 0;
        public int Number { get; set; }
        public UserDeliveryInfo User { get; set; }
        public List<CartItem> Items { get; set; }
        public Order()
        {
            Number = InstanceCounter;
            InstanceCounter += 1;
        }
    }
}