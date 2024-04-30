
namespace OnlineBookShop
{
    public interface IRolesRepository
    {
        void Add(Roles role);
        void Del(Roles role);
        List<Roles> GetAllRoles();
    }
}
