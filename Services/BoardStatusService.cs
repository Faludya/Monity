using Monity.Repositories.Interfaces;
using Monity.Services.Interfaces;

namespace Monity.Services
{
    public class BoardStatusService : IBoardStatusService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public BoardStatusService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
    }
}
