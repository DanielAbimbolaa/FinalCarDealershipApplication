using FinalCarDealershipApplication.Models;

namespace FinalCarDealershipApplication.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUser();
        User GetUserById(string id);
        User GetUserByName(string name);
        bool UserExists(string id);
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        bool Save();
    }
}
