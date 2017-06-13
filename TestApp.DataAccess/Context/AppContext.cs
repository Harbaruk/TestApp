using System.Data.Entity;
using TestApp.DataAccess.Entities;

namespace TestApp.DataAccess.Context
{
    public class AppContext : DbContext, IAppContext
    {
        public AppContext() : base("TestApp")
        {

        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhoneEntity>().HasKey(x => x.Id).ToTable("Phones");
            base.OnModelCreating(modelBuilder);
        }
    }
}
