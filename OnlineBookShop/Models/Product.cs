namespace OnlineBookShop.Models
{
    public class Product
    {
        private static int _instanceCounter = 0;
        public int Id { get;}
        public string Name { get;}
        public string Description { get;}
        public decimal Cost { get;}

        public Product(string name, string description, decimal cost)
        {
            Id = _instanceCounter++;
            Name = name;
            Description = description;
            Cost = cost;
        }

        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Cost}";
        }
    }
}
