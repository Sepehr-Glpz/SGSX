namespace SGSX.Persistense
{
    public abstract class UnitOfWork<T> : QueryUnitOfWork<T>, IUnitOfWork where T : Microsoft.EntityFrameworkCore.DbContext
    {
        protected UnitOfWork() : base()
        {
        }
        ~UnitOfWork()
        {
            Dispose(false);
        }

        public bool SaveChanges()
        {
            var result = DatabaseContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async System.Threading.Tasks.Task<bool> SaveChangesAsync()
        {
            var result = await DatabaseContext.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
