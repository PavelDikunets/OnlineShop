namespace OnlineShopWebApp.Models
{
    public class Product
    {
        private static int InstanceCounter = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public Product()
        {
            Id = InstanceCounter;
            InstanceCounter += 1;
        }
    }
}