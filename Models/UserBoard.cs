using Microsoft.AspNetCore.Identity;

namespace Monity.Models
{
    public class UserBoard
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int BoardId { get; set; }
        public Board? Board { get; set; }
    }
}
