namespace OnlineBookShop
{
    public class InMemoryRolesRepository : IRolesRepository
    {
        public List<Roles> roles = new List<Roles>() { new Roles("Admin") };

        public List<Roles> GetAllRoles()
        {
            return roles;
        }

        public void Add(Roles role)
        {
            roles.Add(role);
        }

        public void Del(Roles role)
        {

            roles.Remove(role);
        }
    }
}
