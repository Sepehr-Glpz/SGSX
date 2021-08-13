namespace SGSX.Persistense
{
    public abstract class QueryUnitOfWork<T> : object, IQueryUnitOfWork where T : Microsoft.EntityFrameworkCore.DbContext 
    {
        protected QueryUnitOfWork() : base()
        {
            IsDisposed = false;
        }

        ~QueryUnitOfWork()
        {
            Dispose(false);
        }

        private T _databaseContext;

        protected T DatabaseContext
        {
            get
            {
                if (_databaseContext is null)
                {
                    var result = System.Activator.CreateInstance(typeof(T)) as T;
                    return result;
                }
                return _databaseContext;
            }
        }

        public bool IsDisposed { get; private set; }

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (IsDisposed == true)
            {
                return;
            }
            if (disposing == true)
            {
                //dispose managed resources
                if (!(_databaseContext is null))
                {
                    _databaseContext.Dispose();
                    _databaseContext = null;
                }
            }

            //dispose unmanaged resources

            IsDisposed = true;
        }

    }
}
