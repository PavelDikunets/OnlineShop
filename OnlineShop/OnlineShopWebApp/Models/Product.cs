namespace OnlineShopWebApp.Controllers
{
    public class Product
    {
        private static int InstanceCounter = 0;
        public int Id { get; }
        private string Name { get; }
        private decimal Cost { get; }
        private string Description { get; }
        public Product(int id, string name, decimal cost, string description)
        {
            Id = id;
            Name = name;
            Cost = cost;
            Description = description;
            InstanceCounter += 1;
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

