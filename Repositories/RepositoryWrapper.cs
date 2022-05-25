using Monity.Models;
using Monity.Repositories.Interfaces;

namespace Monity.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private MonityContext _monityContext;
        public RepositoryWrapper(MonityContext monityContext)
        {
            _monityContext = monityContext;
        }

        public void Save()
        {
            _monityContext.SaveChanges();
        }

        private IAvatarRepository? _avatarRepository;
        public IAvatarRepository AvatarRepository
        {
            get
            {
                if (_avatarRepository == null)
                {
                    _avatarRepository = new AvatarRepository(_monityContext);
                }

                return _avatarRepository;
            }
        }

        private IBoardRepository? _boardRepository;
        public IBoardRepository BoardRepository
        {
            get
            {
                if (_boardRepository == null)
                {
                    _boardRepository = new BoardRepository(_monityContext);
                }

                return _boardRepository;
            }
        }

        private IBoardStatusRepository? _boardStatusRepository;
        public IBoardStatusRepository BoardStatusRepository
        {
            get
            {
                if (_boardStatusRepository == null)
                {
                    _boardStatusRepository = new BoardStatusRepository(_monityContext);
                }

                return _boardStatusRepository;
            }
        }

        private IStatusRepository? _statusRepository;
        public IStatusRepository StatusRepository
        {
            get
            {
                if (_statusRepository == null)
                {
                    _statusRepository = new StatusRepository(_monityContext);
                }

                return _statusRepository;
            }
        }

        private IUserBoardRepository? _userBoardRepository;
        public IUserBoardRepository UserBoardRepository
        {
            get
            {
                if (_userBoardRepository == null)
                {
                    _userBoardRepository = new UserBoardRepository(_monityContext);
                }

                return _userBoardRepository;
            }
        }

        private IUserTaskRepository? _userTaskRepository;

        public IUserTaskRepository UserTaskRepository
        {
            get
            {
                if (_userTaskRepository == null)
                {
                    _userTaskRepository = new UserTaskRepository(_monityContext);
                }

                return _userTaskRepository;
            }
        }

        private IUserRepository? _userRepository;

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_monityContext);
                }

                return _userRepository;
            }
        }
    }
}
