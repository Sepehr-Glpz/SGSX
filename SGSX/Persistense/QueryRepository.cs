using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace SGSX.Persistense
{
    public abstract class QueryRepository<T> : object, IQueryRepository<T> where T : class , Domain.IEntity
    {
        protected QueryRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base()
        {
            DatabaseContext = dbContext ?? throw new System.ArgumentNullException(nameof(dbContext));
            DbSet = DatabaseContext.Set<T>();
        }

        protected Microsoft.EntityFrameworkCore.DbContext DatabaseContext { get; }

        protected Microsoft.EntityFrameworkCore.DbSet<T> DbSet { get; }

        public System.Collections.Generic.List<T> GetAll()
        {
            var result = DbSet.ToList();
            return result;
        }

        public virtual async System.Threading.Tasks.Task<System.Collections.Generic.List<T>> GetAllAsync()
        {
            var result = await DbSet.ToListAsync();
            return result;
        }

        public virtual T GetById(System.Guid id)
        {
            var result = DbSet.Where(current => current.Id == id).FirstOrDefault();
            return result;
        }

        public virtual async System.Threading.Tasks.Task<T> GetByIdAsync(System.Guid id)
        {
            var result = await DbSet.Where(current => current.Id == id).FirstOrDefaultAsync();
            return result;
        }
    }
}
