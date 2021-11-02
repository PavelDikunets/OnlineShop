namespace OnlineShopWebApp.Models
{
    public class Order
    {
        private static int InstanceCounter = 1;
        public int Number { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }
        public Cart Cart { get; set; }
        public Order()
        {
            Number = InstanceCounter;
            InstanceCounter += 1;
        }
    }
}
