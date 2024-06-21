namespace OnlineBookShop
{
    public interface IUsersRepository
    {
        List<User> GetUsers();
        User TryGetById(Guid userId);
        User TryGetByName(string name);
        void Del(Guid userId);
        void AddUser(User user);
        void Edit(EditUser user, Guid userId);
        void ChangePassword(Guid userId, string password);
        void ChangeAccess(Guid userId, string roleName);
    }
}
