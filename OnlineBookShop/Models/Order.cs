namespace OnlineBookShop
{
    public class Order
    {
        private static int _instanceCounter = 0;
        private static int _instance = 0;
        public int Id { get 
            {
                ++_instance;
                if (_instanceCounter > _instance--) return --_instanceCounter;
                return _instanceCounter++;
                
            }
        }
        public Cart Cart { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Comment { get; set; }
    }
}
