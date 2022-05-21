using Monity.Models;

namespace Monity.Services.Interfaces
{
    public interface IUserService
    {
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        User GetUserById(int id);
        List<User> GetAllUsers();
        List<Avatar> GetAvatars();
    }
}
