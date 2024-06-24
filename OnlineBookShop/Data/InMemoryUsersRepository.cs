
namespace OnlineBookShop
{
    public class InMemoryUsersRepository : IUsersRepository
    {
        private readonly List<User> _users = new List<User>()
        {
            new User("Magomed@mail.ru", "12345678", "Магомед", "+79285846357")
        };

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public void ChangeAccess(Guid userId, string roleName)
        {
            var currentUser = TryGetById(userId);
            currentUser.Role.Name = roleName;
        }

        public void ChangePassword(Guid userId, string password)
        {
            var currentUser = TryGetById(userId);
            currentUser.Password = password;
        }

        public void Del(Guid userId)
        {
            var user = TryGetById(userId);
            _users.Remove(user);
        }

        public void Edit(EditUser user, Guid Id)
        {
            var currentUser = TryGetById(Id);
            currentUser.UserName = user.UserName;
            currentUser.Name = user.Name;
            currentUser.PhoneNumber = user.PhoneNumber;
        }

        public List<User> GetUsers()
        {
            return _users;
        }

        public User TryGetById(Guid userId)
        {
            return _users.FirstOrDefault(user => user.Id == userId);
        }

        public User TryGetByName(string name)
        {
            return _users.FirstOrDefault(x => x.UserName == name);
        }
    }
}
