namespace Monity.Models
{
    public class UserTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }

        public int StatusId { get; set; }
        public Status? Status { get; set; }
        public int BoardId{ get; set; }
        public Board? Board{ get; set; }
    }
}
