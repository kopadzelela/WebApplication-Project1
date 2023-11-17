using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebApplication_Project1.DataAccess;
using WebApplication_Project1.Repositories.Interfaces;

namespace WebApplication_Project1.Repositories.Repositories
{
    public class BaseRepository
    {
    }

    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ProjectDBContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public BaseRepository(ProjectDBContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()=> entities.AsEnumerable();
      
        public T Get(int id)=> entities.Find(id);
      
        public void Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            entities.Add(entity);
            context.SaveChanges();
        }
        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            context.SaveChanges();
        }
        public void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            entities.Remove(entity);
            context.SaveChanges();
        }
        public IQueryable<T> FindAll() => context.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)=>
            context.Set<T>().Where(expression).AsNoTracking();
    }
}
