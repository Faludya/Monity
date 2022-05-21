using Monity.Models;
using Monity.Repositories.Interfaces;
using Monity.Services.Interfaces;

namespace Monity.Services
{
    public class UserTaskService : IUserTaskService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UserTaskService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateTask(UserTask userTask)
        {
            _repositoryWrapper.UserTaskRepository.Create(userTask);
            _repositoryWrapper.Save();
        }

        public void DeleteTask(UserTask userTask)
        {
            _repositoryWrapper.UserTaskRepository.Delete(userTask);
            _repositoryWrapper.Save();
        }

        public List<Status> GetBoardStatuses(int boardId)
        {
            return _repositoryWrapper.StatusRepository.GetBoardStatuses(boardId);
        }

        public UserTask GetUserTask(int id)
        {
            return _repositoryWrapper.UserTaskRepository.GetByCondition(c => c.Id == id);
        }

        public UserTask GetUserTaskInclude(int id)
        {
            return _repositoryWrapper.UserTaskRepository.GetUserTaskEagerLoading(c => c.Id == id);
        }

        public void UpdateTask(UserTask userTask)
        {
            _repositoryWrapper.UserTaskRepository.Update(userTask);
            _repositoryWrapper.Save();
        }
    }
}
