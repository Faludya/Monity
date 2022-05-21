namespace Monity.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<BoardStatus>? BoardStatuses { get; set; }
        public ICollection<UserTask>? UserTasks { get; set; }
    }
}
