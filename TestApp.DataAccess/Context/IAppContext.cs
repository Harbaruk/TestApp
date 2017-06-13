using System.Data.Entity;

namespace TestApp.DataAccess.Context
{
    public interface IAppContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
