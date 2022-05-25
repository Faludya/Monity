using Microsoft.AspNetCore.Identity;

namespace Monity.Repositories.Interfaces
{
    public interface IUserRepository : IRepositoryBase<IdentityUser>
    {
        List<IdentityUser> GetAllUsers();
    }
}