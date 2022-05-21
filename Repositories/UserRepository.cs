using Monity.Models;
using Monity.Repositories.Interfaces;

namespace Monity.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(MonityContext monityContext) : base(monityContext)
        {
        }
    }
}
