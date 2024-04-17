using FinalCarDealershipApplication.Data;
using FinalCarDealershipApplication.Interfaces;
using FinalCarDealershipApplication.Models;

namespace FinalCarDealershipApplication.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }


        public bool CreateUser(User userMap)
        {
            try
            {
                _context.Users.Add(userMap);
                var saveChanges = Save();
                return saveChanges;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            return false;
        }

        public bool UserExists(string userId)
        {
            return _context.Users.Any(u => u.userId == userId);
        }

        public ICollection<User> GetUsers()
        {
            var userList = _context.Users.ToList();
            return userList;
        }

        public User GetUserById(string id)
        {
            return _context.Users.Where(u => u.userId == id).FirstOrDefault();
        }

        public User GetUserByName(string name)
        {
            return _context.Users.Where(u => u.Name == name).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateUser(User user)
        {
            _context.Update(user);
            return Save();
        }

        public ICollection<User> GetUser()
        {
            var userList = _context.Users.ToList();
            return userList;
        }

        public bool DeleteUser(User user)
        {
            _context.Remove(user);
            return Save();
        }
    }
}
