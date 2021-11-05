namespace OnlineShopWebApp.Models
{
    public class Product
    {
        private static int InstanceCounter = 0;
        public int Id { get; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public Product(string name, decimal cost, string description)
        {
            Id = InstanceCounter;
            Name = name;
            Cost = cost;
            Description = description;
            InstanceCounter += 1;
        }
    }
}