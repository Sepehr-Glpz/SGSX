namespace SGSX.Persistense
{
    public abstract class Repository<T> : QueryRepository<T> , IRepository<T> where T : class, Domain.IEntity
    {
        protected Repository(Microsoft.EntityFrameworkCore.DbContext dbContext ) : base(dbContext)
        {
        }

        public virtual void Delete(T entity)
        {
            DbSet.Remove(entity ?? throw new System.ArgumentNullException(nameof(entity)));
        }

        public virtual async System.Threading.Tasks.Task DeleteAsync(T entity)
        {
            await System.Threading.Tasks.Task.Run(() =>
            {
                DbSet.Remove(entity ?? throw new System.ArgumentNullException(nameof(entity)));
            });
        }

        public virtual bool DeleteById(System.Guid id)
        {
            var requestedEntity = GetById(id);
            if (requestedEntity is null)
            {
                return false;
            }
            DbSet.Remove(requestedEntity);
            return true;
        }

        public virtual async System.Threading.Tasks.Task<bool> DeleteByIdAsync(System.Guid id)
        {
            var requestedEntity = await GetByIdAsync(id);
            if (requestedEntity is null)
            {
                return false;
            }
            await System.Threading.Tasks.Task.Run(() =>
            {
                DbSet.Remove(requestedEntity);
            });
            return true;
        }

        public virtual void DeleteGroup(params T[] entities)
        {
            DbSet.RemoveRange(entities ?? throw new System.ArgumentNullException(nameof(entities)));
        }

        public virtual async System.Threading.Tasks.Task DeleteGroupAsync(params T[] entities)
        {
            await System.Threading.Tasks.Task.Run(() =>
            {
                DbSet.RemoveRange(entities ?? throw new System.ArgumentNullException(nameof(entities)));
            });
        }

        public virtual void Insert(T entity)
        {
            DbSet.Add(entity ?? throw new System.ArgumentNullException(nameof(entity)));
        }

        public virtual async System.Threading.Tasks.Task InsertAsync(T entity)
        {
            await DbSet.AddAsync(entity ?? throw new System.ArgumentNullException(nameof(entity)));
        }
        public virtual void Update(T entity)
        {
            DbSet.Update(entity ?? throw new System.ArgumentNullException(nameof(entity)));
        }

        public virtual async System.Threading.Tasks.Task UpdateAsync(T entity)
        {
            await System.Threading.Tasks.Task.Run(() =>
            {
                DbSet.Update(entity ?? throw new System.ArgumentNullException(nameof(entity)));
            });
        }

        public virtual void UpdateGroup(params T[] entities)
        {
            DbSet.UpdateRange(entities ?? throw new System.ArgumentNullException(nameof(entities)));
        }

        public virtual async System.Threading.Tasks.Task UpdateGroupAsync(params T[] entities)
        {
            await System.Threading.Tasks.Task.Run(() =>
            {
                DbSet.UpdateRange(entities ?? throw new System.ArgumentNullException(nameof(entities)));
            });
        }
    }
}
