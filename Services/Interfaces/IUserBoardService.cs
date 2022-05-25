using Monity.Models;

namespace Monity.Services.Interfaces
{
    public interface IUserBoardService
    {
        void CreateUserBoard(UserBoard userBoard);
        void UpdateUserBoard(UserBoard userBoard);
        void DeleteUserBoard(UserBoard userBoard);
        UserBoard GetUserBoardById(int id);
        UserBoard GetUserBoardByUserAndBoardId(string userId, int boardId);
        List<UserBoard> GetUsersByBoardId(int boardId);
    }
}
