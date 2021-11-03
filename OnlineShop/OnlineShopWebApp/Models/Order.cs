namespace OnlineShopWebApp.Models
{
    public class Order
    {
        private static int InstanceCounter = 1;
        public int Number { get; set; }
        public string Comments { get; set; }
        public User User { get; set; }
        public Cart Cart { get; set; }
        public Order()
        {
            Number = InstanceCounter;
            InstanceCounter += 1;
        }
    }
}
