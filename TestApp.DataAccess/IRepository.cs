using System.Linq;

namespace TestApp.DataAccess
{
    public interface IRepository<T> where T : class
    {
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteById(object id);
        IQueryable<T> Set { get; }
        void RemoveRange(IQueryable<T> entities);
    }
}
