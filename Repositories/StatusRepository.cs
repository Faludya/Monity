using Monity.Models;
using Monity.Repositories.Interfaces;

namespace Monity.Repositories
{
    public class StatusRepository : RepositoryBase<Status>, IStatusRepository
    {
        public StatusRepository(MonityContext monityContext) : base(monityContext)
        {
        }

        public List<Status> GetBoardStatuses(int boardId)
        {
            var boardStatusList = MonityContext.BoardStatuses.Where(c => c.BoardId == boardId).ToList();
            var statusList = new List<Status>();

            foreach(var boardStatus in boardStatusList)
            {
                statusList.Add(MonityContext.Statuses.Where(c => c.Id == boardStatus.StatusId).FirstOrDefault());
            }

            return statusList;
        }
    }
}
