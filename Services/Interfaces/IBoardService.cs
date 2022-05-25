using Monity.Models;

namespace Monity.Services.Interfaces
{
    public interface IBoardService
    {
        void CreateBoard(Board board, string userId);
        void UpdateBoard(Board board);
        void DeleteBoard(Board board);
        List<Board> GetBoardsByUserId(string userId);
        List<Board> GetAllBoards();
        Board GetBoardById(int boardId);
    }
}
