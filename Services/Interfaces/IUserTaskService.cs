using Monity.Models;

namespace Monity.Services.Interfaces
{
    public interface IUserTaskService
    {
        UserTask GetUserTask(int id);
        UserTask GetUserTaskInclude(int id);
        void CreateTask(UserTask userTask);
        void UpdateTask(UserTask userTask);
        void DeleteTask(UserTask userTask);
        List<Status> GetBoardStatuses(int boardId);
    }
}
