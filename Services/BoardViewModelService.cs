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

        public BoardContainer GetBoardContainer(int boardId)
        {
            var containter = new BoardContainer();
            containter.Board = _repositoryWrapper.BoardRepository.
                                GetByCondition(c => c.Id == boardId);
            containter.BoardStatuses = _repositoryWrapper.BoardStatusRepository.
                                     FindByCondition(c => c.BoardId == boardId).ToList();
            containter.UserTasks = _repositoryWrapper.UserTaskRepository.
                                    FindByCondition(c => c.BoardId == boardId).ToList();
            containter.Statuses = new List<Status>();

            foreach (BoardStatus bs in containter.BoardStatuses)
            {
                var test = _repositoryWrapper.StatusRepository.
                                        GetByCondition(c => c.Id == bs.StatusId);
                containter.Statuses.Add(test);
            }

            return containter;
        }

        public BoardViewModel GetBoardViewModel(string userId)
        {
            string id = userId;

            var boardVm = new BoardViewModel();
            boardVm.Boards = new List<BoardContainer>();

            boardVm.UserBoards = _repositoryWrapper.UserBoardRepository.
                                    FindByCondition(c => c.UserId == id.ToString()).ToList();
            
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

            if(boardVm.Boards.Count > 0)
                boardVm.SelectedBoard = boardVm.Boards[0];
    
            return boardVm;
        }

        public BoardViewModel GetBoardViewModel(int selectedBoardId, string userId, string overdue)
        {
            string id = userId;

            var boardVm = new BoardViewModel();
            boardVm.Boards = new List<BoardContainer>();

            boardVm.UserBoards = _repositoryWrapper.UserBoardRepository.
                                    FindByCondition(c => c.UserId == id.ToString()).ToList();

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

                    case "week":
                        DateTime StartOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
                        DateTime EndOfWeek = StartOfWeek.AddDays(7);

                        containter.UserTasks = _repositoryWrapper.UserTaskRepository.
                                        FindByCondition(c => c.BoardId == userBoard.BoardId && c.DueDate <= EndOfWeek).ToList();
                        break;
                    case "month":
                        var StartOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                        var noDaysInMonth = DateTime.DaysInMonth(StartOfMonth.Year, StartOfMonth.Month);
                        var EndOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddDays(noDaysInMonth - 1);

                        containter.UserTasks = _repositoryWrapper.UserTaskRepository.
                                        FindByCondition(c => c.BoardId == userBoard.BoardId && c.DueDate <= EndOfMonth).ToList();
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

            foreach(var board in boardVm.Boards)
            {
                if(board.Board.Id == selectedBoardId)
                {
                    boardVm.SelectedBoard = board;
                    break;
                }
            }

            return boardVm;
        }
    }
}
