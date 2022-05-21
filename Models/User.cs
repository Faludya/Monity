namespace Monity.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int AvatarId { get; set; }
        public Avatar? Avatar { get; set; }

        public ICollection<UserBoard>? UserBoards { get; set; }
    }
}
