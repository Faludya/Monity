using Monity.Models;

namespace Monity.Repositories.Interfaces
{
    public interface IStatusRepository : IRepositoryBase<Status>
    {
        List<Status> GetBoardStatuses(int boardId);
    }
}
