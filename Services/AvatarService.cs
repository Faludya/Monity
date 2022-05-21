using Monity.Repositories.Interfaces;
using Monity.Services.Interfaces;

namespace Monity.Services
{
    public class AvatarService : IAvatarService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public AvatarService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public string GetAvatar(string avatarId)
        {
            return _repositoryWrapper.AvatarRepository.FindByCondition(l => l.Id == 1).FirstOrDefault().ToString();
        }
    }
}
