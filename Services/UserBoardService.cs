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
    }
}
