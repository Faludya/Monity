using Monity.Models;
using Monity.Repositories.Interfaces;

namespace Monity.Repositories
{
    public class BoardStatusRepository : RepositoryBase<BoardStatus>, IBoardStatusRepository
    {
        public BoardStatusRepository(MonityContext monityContext) : base(monityContext)
        {
        }
    }
}
