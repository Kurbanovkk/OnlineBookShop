
using System.Data;
using OnlineBookShop.Db.Models;


namespace OnlineBookShop.Db
{
    public interface IRolesRepository
    {
        void Add(Roles role);
        void Del(Roles role);
        List<Roles> GetAllRoles();
    }
}
