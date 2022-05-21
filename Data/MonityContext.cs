using Microsoft.EntityFrameworkCore;

namespace Monity.Models
{
    public class MonityContext : DbContext
    {
        public MonityContext(DbContextOptions<MonityContext> options)
            : base(options)
        {
        }

        public DbSet<Avatar>? Avatars { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<UserBoard>? UserBoards { get; set; }
        public DbSet<Board>? Boards { get; set; }
        public DbSet<BoardStatus>? BoardStatuses{ get; set; }
        public DbSet<Status>? Statuses{ get; set; }
        public DbSet<UserTask>? UserTasks{ get; set; }
    }
}