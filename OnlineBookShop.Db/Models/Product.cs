using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Db.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public string Link { get; set; }

        public CartItem CartItem { get; set; }
    }
}
