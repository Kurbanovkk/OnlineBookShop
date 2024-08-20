using System.ComponentModel.DataAnnotations;

namespace OnlineBookShop
{
    public class UserDeliveryInfo
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public string Comment { get; set; }
    }
}