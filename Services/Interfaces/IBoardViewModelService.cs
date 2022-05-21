using Monity.Models;
using Monity.ViewModels;

namespace Monity.Services.Interfaces
{
    public interface IBoardViewModelService
    {
        BoardViewModel GetBoardViewModel();
        BoardViewModel GetBoardViewModel(string overdue);
    }
}
