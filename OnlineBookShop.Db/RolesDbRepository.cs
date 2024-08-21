using OnlineBookShop.Db.Models;
namespace OnlineBookShop.Db
{
    public class RolesDbRepository : IRolesRepository
    {
        private readonly DatabaseContext _databaseContext;

        public RolesDbRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<Roles> GetAllRoles()
        {
            return _databaseContext.Roles.ToList();
        }

        public void Add(Roles role)
        {
			_databaseContext.Roles.Add(role);
        }

        public void Del(Roles role)
        {

			_databaseContext.Roles.Remove(role);
        }
    }
}
