namespace Monity.Models
{
    public class Board
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }

        public ICollection<UserBoard>? UserBoards { get; set; }
        public ICollection<BoardStatus>? BoardStatuses { get; set; }
        public ICollection<UserTask>? UserTasks{ get; set; }
    }
}
