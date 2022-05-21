using Monity.Models;

namespace Monity.ViewModels
{
    public class BoardContainer
    {
        public Board Board { get; set; }
        public List<BoardStatus> BoardStatuses { get; set; }
        public List<Status> Statuses { get; set; }
        public List<UserTask> UserTasks { get; set; }
    }
}
