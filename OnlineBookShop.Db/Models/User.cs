using System.ComponentModel.DataAnnotations;
using System.Data;

namespace OnlineBookShop.Db.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public Roles Role { get; set; }
    }
}
