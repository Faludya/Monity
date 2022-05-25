using Microsoft.AspNetCore.Identity;

namespace Monity.Services.Interfaces
{
    public interface IUserService
    {
        List<IdentityUser> GetAllUsers();
        List<IdentityUser> GetUsersOfBoard(int boardId);
    }
}
