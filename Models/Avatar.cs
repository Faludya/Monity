namespace Monity.Models
{
    public class Avatar
    {
        public int Id { get; set; }
        public string WebAddress { get; set; }

        public ICollection<User>? Users { get; set; }
    }
}
