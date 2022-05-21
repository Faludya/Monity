using Monity.Models;
using Monity.Repositories.Interfaces;
using Monity.ViewModels;

namespace Monity.Repositories
{
    public class BoardViewModelRepository : RepositoryBase<BoardViewModel>, IBoardViewModelRepository
    {
        public BoardViewModelRepository(MonityContext monityContext) : base(monityContext)
        {
        }
    }
}
