using System.ComponentModel.DataAnnotations;

namespace OnlineBookShop.Db.Models
{
    public class Roles
    {
        public string Name { get; set; }

        public Roles() { }
        public Roles(string name)
        {
            Name = name;
        }
    }
}
