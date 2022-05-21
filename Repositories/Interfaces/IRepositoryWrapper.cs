﻿namespace Monity.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        IAvatarRepository AvatarRepository{ get; }
        IBoardRepository BoardRepository{ get; }
        IBoardStatusRepository BoardStatusRepository{ get; }
        IStatusRepository StatusRepository{ get; }
        IUserBoardRepository UserBoardRepository{ get; }
        IUserRepository UserRepository{ get; }
        IUserTaskRepository UserTaskRepository{ get; }

        void Save();
    }
}
