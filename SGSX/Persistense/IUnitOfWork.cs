namespace SGSX.Persistense
{
    public interface IUnitOfWork : IQueryUnitOfWork
    {
        bool SaveChanges();

        System.Threading.Tasks.Task<bool> SaveChangesAsync();
    }
}
