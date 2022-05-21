using Microsoft.EntityFrameworkCore;
using Monity.Models;
using Monity.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Monity.Repositories
{
    public class UserTaskRepository : RepositoryBase<UserTask>, IUserTaskRepository
    {
        public UserTaskRepository(MonityContext monityContext) : base(monityContext)
        {
        }

        public UserTask GetUserTaskEagerLoading(Expression<Func<UserTask, bool>> expression)
        {
            var userTask = new UserTask();
            userTask =  this.MonityContext.UserTasks.Where(expression)
                        .Include(s => s.Status)
                        .Include(b => b.Board)
                        .FirstOrDefault();
            
            return userTask;
        }
    }
}
