using Monity.Models;
using Monity.Repositories.Interfaces;
using Monity.Services.Interfaces;

namespace Monity.Services
{
    public class StatusService : IStatusService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public StatusService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateStatus(Status status, int boardId)
        {
            _repositoryWrapper.StatusRepository.Create(status);
            _repositoryWrapper.Save();

            var boardStatus = new BoardStatus()
            {
                BoardId = boardId,
                StatusId = status.Id,
            };
            _repositoryWrapper.BoardStatusRepository.Create(boardStatus);
            _repositoryWrapper.Save();
        }

        public void DeleteStatus(Status status)
        {
            _repositoryWrapper.StatusRepository.Delete(status);
            _repositoryWrapper.Save();
        }

        public Status GetStatusById(int id)
        {
            return _repositoryWrapper.StatusRepository.GetByCondition(c => c.Id == id);
        }

        public List<Status> GetStatusesByBoardId(int boardId)
        {
            return _repositoryWrapper.StatusRepository.GetBoardStatuses(boardId);
        }

        public void UpdateStatus(Status status)
        {
            _repositoryWrapper.StatusRepository.Update(status);
            _repositoryWrapper.Save();
        }
    }
}
