using Microsoft.AspNetCore.Identity;
using Monity.Models;
using Monity.Repositories.Interfaces;

namespace Monity.Repositories
{
    public class UserRepository : RepositoryBase<IdentityUser>, IUserRepository
    {
        public UserRepository(MonityContext monityContext) : base(monityContext)
        {
        }

        public List<IdentityUser> GetAllUsers()
        {
            return MonityContext.Users.ToList();
        }
    }
}
