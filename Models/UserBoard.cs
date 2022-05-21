namespace Monity.Models
{
    public class UserBoard
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BoardId { get; set; }

        public User? User { get; set; }
        public Board? Board { get; set; }
    }
}
