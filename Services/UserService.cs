using Microsoft.AspNetCore.Identity;
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

        public List<IdentityUser> GetAllUsers()
        {
            return _repositoryWrapper.UserRepository.GetAllUsers();
        }

        public List<IdentityUser> GetUsersOfBoard(int boardId)
        {
            var userBoardList = _repositoryWrapper.UserBoardRepository.FindByCondition(c => c.BoardId == boardId).ToList();
            var usersList = new List<IdentityUser>();

            foreach(var userBoard in userBoardList)
            {
                var temp = _repositoryWrapper.UserRepository.FindByCondition(c => c.Id == userBoard.UserId).FirstOrDefault();
                usersList.Add(temp);
            }

            return usersList;
        }
    }
}
