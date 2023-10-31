using Data.Context;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly ApplicationDbContext _db;

        internal DbSet<TEntity> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            dbSet = _db.Set<TEntity>();
        }
        public bool Add(TEntity item)
        {
            var result = dbSet.Add(item);
            if (result == null) return false;
            _db.SaveChanges();
            return true;
        }

        public IEnumerable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = dbSet;
            
            return query.ToList();
        }

        public TEntity GetFirstorDefault(Expression<Func<TEntity, bool>> filter)
        {
            IQueryable<TEntity> query = dbSet.Where(filter);
            
            return query.FirstOrDefault();
        }

        public bool Remove(TEntity item)
        {
            var result = dbSet.Remove(item);
            if (result == null) return false;
            _db.SaveChanges();
            return true;
        }

        public bool Update(TEntity item)
        {
            var result = dbSet.Update(item);
            if (result == null) return false;
            _db.SaveChanges();
            return true;
        }
    }
}
