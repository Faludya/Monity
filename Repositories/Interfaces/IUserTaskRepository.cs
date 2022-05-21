using Monity.Models;
using System.Linq.Expressions;

namespace Monity.Repositories.Interfaces
{
    public interface IUserTaskRepository : IRepositoryBase<UserTask>
    {
        UserTask GetUserTaskEagerLoading(Expression<Func<UserTask, bool>> expression);
    }
}
