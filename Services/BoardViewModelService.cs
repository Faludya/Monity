using Monity.Models;
using Monity.Repositories.Interfaces;
using Monity.Services.Interfaces;
using Monity.ViewModels;

namespace Monity.Services
{
    public class BoardViewModelService : IBoardViewModelService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public BoardViewModelService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public BoardViewModel GetBoardViewModel()
        {
            int id = 1;

            var boardVm = new BoardViewModel();
            boardVm.Boards = new List<BoardContainer>();

            boardVm.UserBoards = _repositoryWrapper.UserBoardRepository.
                                    FindByCondition(c => c.UserId == id).ToList();
            
            foreach(var userBoard in boardVm.UserBoards)
            {
                var containter = new BoardContainer();
                containter.Board = _repositoryWrapper.BoardRepository.
                                    GetByCondition(c => c.Id == userBoard.BoardId);
                containter.BoardStatuses = _repositoryWrapper.BoardStatusRepository.
                                         FindByCondition(c => c.BoardId == userBoard.BoardId).ToList();
                containter.UserTasks = _repositoryWrapper.UserTaskRepository.
                                        FindByCondition(c => c.BoardId == userBoard.BoardId).ToList();
                containter.Statuses = new List<Status>();

                foreach(BoardStatus bs in containter.BoardStatuses)
                {
                    var test = _repositoryWrapper.StatusRepository.
                                            GetByCondition(c => c.Id == bs.StatusId);
                    containter.Statuses.Add(test);
                }
                
                boardVm.Boards.Add(containter);
            }

            boardVm.SelectedBoard = boardVm.Boards[0];
            return boardVm;
        }

        public BoardViewModel GetBoardViewModel(string overdue)
        {
            int id = 1;

            var boardVm = new BoardViewModel();
            boardVm.Boards = new List<BoardContainer>();

            boardVm.UserBoards = _repositoryWrapper.UserBoardRepository.
                                    FindByCondition(c => c.UserId == id).ToList();

            foreach (var userBoard in boardVm.UserBoards)
            {
                var containter = new BoardContainer();
                containter.Board = _repositoryWrapper.BoardRepository.
                                    GetByCondition(c => c.Id == userBoard.BoardId);
                containter.BoardStatuses = _repositoryWrapper.BoardStatusRepository.
                                         FindByCondition(c => c.BoardId == userBoard.BoardId).ToList();
                switch (overdue)
                {
                    case "overdue":
                        containter.UserTasks = _repositoryWrapper.UserTaskRepository.
                                        FindByCondition(c => c.BoardId == userBoard.BoardId && c.DueDate < DateTime.Now).ToList();
                        break;

                    default:
                        containter.UserTasks = _repositoryWrapper.UserTaskRepository.
                                        FindByCondition(c => c.BoardId == userBoard.BoardId).ToList();
                        break;
                }

                containter.Statuses = new List<Status>();

                foreach (BoardStatus bs in containter.BoardStatuses)
                {
                    var test = _repositoryWrapper.StatusRepository.
                                            GetByCondition(c => c.Id == bs.StatusId);
                    containter.Statuses.Add(test);
                }

                boardVm.Boards.Add(containter);
            }

            boardVm.SelectedBoard = boardVm.Boards[0];

            return boardVm;
        }
    }
}
