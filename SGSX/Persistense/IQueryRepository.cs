namespace SGSX.Persistense
{
    public interface IQueryRepository<T> where T : Domain.IEntity
    {
        T GetById(System.Guid id);

        System.Threading.Tasks.Task<T> GetByIdAsync(System.Guid id);

        System.Collections.Generic.List<T> GetAll();

        System.Threading.Tasks.Task<System.Collections.Generic.List<T>> GetAllAsync();
    }
}
