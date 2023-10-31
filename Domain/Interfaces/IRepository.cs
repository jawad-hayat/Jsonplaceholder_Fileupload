
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetFirstorDefault(Expression<Func<T, bool>> filter);
        bool Add(T item);
        bool Remove(T item);
        bool Update(T item);
    }
}
