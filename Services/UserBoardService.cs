using Monity.Models;
using Monity.Repositories.Interfaces;
using Monity.Services.Interfaces;

namespace Monity.Services
{
    public class UserBoardService : IUserBoardService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UserBoardService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateUserBoard(UserBoard userBoard)
        {
            _repositoryWrapper.UserBoardRepository.Create(userBoard);
            _repositoryWrapper.Save();
        }

        public void DeleteUserBoard(UserBoard userBoard)
        {
            _repositoryWrapper.UserBoardRepository.Delete(userBoard);
            _repositoryWrapper.Save();
        }

        public UserBoard GetUserBoardById(int id)
        {
            return _repositoryWrapper.UserBoardRepository.FindByCondition(c => c.Id == id).FirstOrDefault();
        }

        public UserBoard GetUserBoardByUserAndBoardId(string userId, int boardId)
        {
            return _repositoryWrapper.UserBoardRepository.FindByCondition(c => c.BoardId == boardId && c.UserId == userId).FirstOrDefault();
        }

        public List<UserBoard> GetUsersByBoardId(int boardId)
        {
            return _repositoryWrapper.UserBoardRepository.FindByCondition(c=> c.BoardId == boardId).ToList();
        }

        public void UpdateUserBoard(UserBoard userBoard)
        {
            _repositoryWrapper.UserBoardRepository.Update(userBoard);
            _repositoryWrapper.Save();
        }
    }
}
