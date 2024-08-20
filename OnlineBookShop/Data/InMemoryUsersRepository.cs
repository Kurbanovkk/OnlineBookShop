
namespace OnlineBookShop
{
    public class InMemoryUsersRepository : IUsersRepository
    {
        private readonly List<UserViewModel> _users = new List<UserViewModel>()
        {
            new UserViewModel("Magomed@mail.ru", "12345678", "Магомед", "+79285846357")
        };

        public void AddUser(UserViewModel user)
        {
            _users.Add(user);
        }

        public void ChangeAccess(Guid id, string roleName)
        {
            var currentUser = TryGetById(id);
            currentUser.Role.Name = roleName;
        }

        public void ChangePassword(Guid id, string password)
        {
            var currentUser = TryGetById(id);
            currentUser.Password = password;
        }

        public void Del(Guid id)
        {
            var user = TryGetById(id);
            _users.Remove(user);
        }

        public List<UserViewModel> GetUsers()
        {
            return _users;
        }

        public UserViewModel TryGetById(Guid id)
        {
            return _users.FirstOrDefault(user => user.Id == id);
        }

        public UserViewModel TryGetByName(string name)
        {
            return _users.FirstOrDefault(x => x.UserName == name);
        }
    }
}
