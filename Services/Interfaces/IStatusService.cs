using Monity.Models;

namespace Monity.Services.Interfaces
{
    public interface IStatusService
    {
        void CreateStatus(Status status, int boardId);
        void UpdateStatus(Status status);
        void DeleteStatus(Status status);
        Status GetStatusById(int id);
        List<Status> GetStatusesByBoardId(int boardId);
    }
}
