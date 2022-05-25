namespace Monity.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        IAvatarRepository AvatarRepository{ get; }
        IBoardRepository BoardRepository{ get; }
        IBoardStatusRepository BoardStatusRepository{ get; }
        IStatusRepository StatusRepository{ get; }
        IUserBoardRepository UserBoardRepository{ get; }
        IUserTaskRepository UserTaskRepository{ get; }
        IUserRepository UserRepository{ get; }
        void Save();
    }
}
