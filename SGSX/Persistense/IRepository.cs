namespace SGSX.Persistense
{
    public interface IRepository<T> : IQueryRepository<T> where T : Domain.IEntity 
    {
        void Insert(T entity);

        System.Threading.Tasks.Task InsertAsync(T entity);

        void Update(T entity);

        System.Threading.Tasks.Task UpdateAsync(T entity);

        void Delete(T entity);

        System.Threading.Tasks.Task DeleteAsync(T entity);

        bool DeleteById(System.Guid id);

        System.Threading.Tasks.Task<bool> DeleteByIdAsync(System.Guid id);

        void DeleteGroup(params T[] entities);

        System.Threading.Tasks.Task DeleteGroupAsync(params T[] entities);

        void UpdateGroup(params T[] entities);

        System.Threading.Tasks.Task UpdateGroupAsync(params T[] entities);
    }
}
