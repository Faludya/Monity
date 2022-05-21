namespace Monity.Models
{
    public class BoardStatus
    {
        public int Id { get; set; }
        public int BoardId { get; set; }
        public int StatusId { get; set; }

        public Board? Board { get; set; }
        public Status? Status { get; set; }
    }
}
