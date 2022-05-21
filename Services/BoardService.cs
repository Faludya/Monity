using Monity.Models;
using Monity.Repositories.Interfaces;
using Monity.Services.Interfaces;

namespace Monity.Services
{
    public class BoardService : IBoardService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public BoardService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateBoard(Board board, int userId)
        {
            board.CreationDate = DateTime.Now;
            _repositoryWrapper.BoardRepository.Create(board);
            _repositoryWrapper.Save();

            var userBoard = new UserBoard()
            {
                UserId = userId.ToString(),
                BoardId = board.Id
            };

            _repositoryWrapper.UserBoardRepository.Create(userBoard);
            _repositoryWrapper.Save();
        }

        public void DeleteBoard(Board board)
        {
           _repositoryWrapper.BoardRepository.Delete(board);
            _repositoryWrapper.Save();
        }

        public Board GetBoardById(int boardId)
        {
            return _repositoryWrapper.BoardRepository.GetByCondition(c => c.Id == boardId);
        }

        public List<Board> GetBoardsByUserId(int userId)
        {
           var userBoards = _repositoryWrapper.UserBoardRepository.FindByCondition(c => c.UserId == userId.ToString()).ToList();
           var boardsList = new List<Board>();

            foreach(var board in userBoards)
            {
                boardsList.Add(_repositoryWrapper.BoardRepository.GetByCondition(c => c.Id == board.BoardId));
            }
            
            return boardsList;
        }

        public void UpdateBoard(Board board)
        {
            _repositoryWrapper.BoardRepository.Update(board);
            _repositoryWrapper.Save();
        }
    }
}
