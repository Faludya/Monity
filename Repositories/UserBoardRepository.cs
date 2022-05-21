using Monity.Models;
using Monity.Repositories.Interfaces;

namespace Monity.Repositories
{
    public class UserBoardRepository : RepositoryBase<UserBoard>, IUserBoardRepository
    {
        public UserBoardRepository(MonityContext monityContext) : base(monityContext)
        {
        }
    }
}
