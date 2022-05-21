using Monity.Models;

namespace Monity.ViewModels
{
    public class BoardViewModel
    {
        public List<UserBoard> UserBoards { get; set; }
        public List<BoardContainer> Boards { get; set; }
        public BoardContainer SelectedBoard { get; set; }
    }
}
