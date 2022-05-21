using Monity.Models;
using Monity.Repositories.Interfaces;

namespace Monity.Repositories
{
    public class AvatarRepository : RepositoryBase<Avatar>, IAvatarRepository
    {
        public AvatarRepository(MonityContext monityContext) : base(monityContext)
        {
        }
    }
}
