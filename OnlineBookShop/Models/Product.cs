namespace OnlineBookShop
{
    public class Product
    {
        private static int _instanceCounter = 0;
        public int Id { get;}
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public string Link { get; set; }

        public Product(string name, string description, decimal cost, string link)
        {
            Id = ++_instanceCounter;
            Name = name;
            Description = description;
            Cost = cost;
            Link = link;
        }

        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Cost}";
        }
    }
}
