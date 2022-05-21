using Monity.Models;

namespace Monity.Services.Interfaces
{
    public interface IBoardService
    {
        void CreateBoard(Board board, int userId);
        void UpdateBoard(Board board);
        void DeleteBoard(Board board);
        List<Board> GetBoardsByUserId(int userId);
        Board GetBoardById(int boardId);
    }
}
