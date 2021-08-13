namespace SGSX.Persistense
{
    public interface IQueryUnitOfWork : System.IDisposable
    {
        bool IsDisposed { get; }
    }
}
