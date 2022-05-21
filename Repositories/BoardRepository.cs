using Monity.Models;
using Monity.Repositories.Interfaces;

namespace Monity.Repositories
{
    public class BoardRepository : RepositoryBase<Board>, IBoardRepository
    {
        public BoardRepository(MonityContext monityContext) : base(monityContext)
        {
        }
    }
}
