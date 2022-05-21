using Monity.Models;
using Monity.Repositories.Interfaces;
using Monity.Services.Interfaces;

namespace Monity.Services
{
    public class UserService : IUserService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateUser(User user)
        {
            _repositoryWrapper.UserRepository.Create(user);
            _repositoryWrapper.Save();
        }

        public void DeleteUser(User user)
        {
            _repositoryWrapper.UserRepository.Delete(user);
            _repositoryWrapper.Save();
        }

        public User GetUserById(int id)
        {
            return _repositoryWrapper.UserRepository.GetByCondition(i => i.Id == id);
        }

        public List<User> GetAllUsers()
        {
            return _repositoryWrapper.UserRepository.FindAll().ToList();
        }

        public void UpdateUser(User user)
        {
            _repositoryWrapper.UserRepository.Update(user);
            _repositoryWrapper.Save();
        }

        public List<Avatar> GetAvatars()
        {
            return _repositoryWrapper.AvatarRepository.FindAll().ToList();
        }
    }
}
