using Monity.Models;
using Monity.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace Monity.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected MonityContext MonityContext{ get; set; }

        public RepositoryBase(MonityContext monityContext)
        {
            this.MonityContext = monityContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.MonityContext.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.MonityContext.Set<T>().Where(expression);
        }
        public T GetByCondition(Expression<Func<T, bool>> expression)
        {
            return this.MonityContext.Set<T>().Where(expression).FirstOrDefault();
        }

        public void Create(T entity)
        {
            this.MonityContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.MonityContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.MonityContext.Set<T>().Remove(entity);
        }
    }
}
