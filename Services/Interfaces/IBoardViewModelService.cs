using Monity.Models;
using Monity.ViewModels;

namespace Monity.Services.Interfaces
{
    public interface IBoardViewModelService
    {
        BoardViewModel GetBoardViewModel(string userId);
        BoardViewModel GetBoardViewModel(int selectedBoardId, string userId, string overdue);
        BoardContainer GetBoardContainer(int boardId);
    }
}
