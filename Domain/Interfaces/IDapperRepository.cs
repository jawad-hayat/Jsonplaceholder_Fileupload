
namespace Domain.Interfaces
{
    public interface IDapperRepository<TEntity> where TEntity : class 
    {
        IEnumerable<TEntity> GetAll();
        TEntity? GetById(int id);
        bool Insert(TEntity item);
        bool Update(TEntity item);
        bool Delete(int id);
    }
}
