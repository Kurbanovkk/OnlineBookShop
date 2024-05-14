
namespace OnlineBookShop
{
    public class InMemoryUsersRepository : IUsersRepository
    {
        private readonly List<User> _users = new List<User>()
        {
            new User("Magomed@mail.ru", "12345678", "Магомед", "+79285846357"),
            new User("Musa@mail.ru", "12345678", "Муса", "+79284875124")
        };

        public void Add(User user)
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

        public void Edit(EditUser user, Guid userId)
        {
            var currentUser = TryGetById(userId);
            currentUser.Name = user.UserName;
            currentUser.Name = user.Name;
            currentUser.Phone = user.Phone;
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
