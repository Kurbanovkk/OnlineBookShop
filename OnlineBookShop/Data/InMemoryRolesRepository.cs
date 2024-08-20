namespace OnlineBookShop
{
    public class InMemoryRolesRepository : IRolesRepository
    {
        public List<RolesViewModel> roles = new List<RolesViewModel>() { new RolesViewModel("Admin") };

        public List<RolesViewModel> GetAllRoles()
        {
            return roles;
        }

        public void Add(RolesViewModel role)
        {
            roles.Add(role);
        }

        public void Del(RolesViewModel role)
        {

            roles.Remove(role);
        }
    }
}
