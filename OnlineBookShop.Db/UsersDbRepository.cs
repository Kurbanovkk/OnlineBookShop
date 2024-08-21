using OnlineBookShop.Db.Models;
namespace OnlineBookShop.Db
{
    public class UsersDbRepository : IUsersRepository
    {
		private readonly DatabaseContext _dataBaseContext;

		public UsersDbRepository(DatabaseContext dataBaseContext)
		{
			_dataBaseContext = dataBaseContext;
		}
		private readonly List<User> _users = new List<User>();

        public void AddUser(User user)
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

        public List<User> GetUsers()
        {
            return _users;
        }

        public User TryGetById(Guid id)
        {
            return _users.FirstOrDefault(user => user.Id == id);
        }

        public User TryGetByName(string name)
        {
            return _users.FirstOrDefault(x => x.UserName == name);
        }
    }
}
