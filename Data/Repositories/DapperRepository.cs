using Dapper;
using Data.Context;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.Extensions.Configuration;

namespace Data.Repositories
{
    public class DapperRepository<TEntity> : DbConnectionDapper , IDapperRepository<TEntity> where TEntity : class
    {
        public readonly string tableName;
        public readonly string idKey;
        public readonly string insertQuery;
        public readonly string updateQuery;
        public DapperRepository(IConfiguration config) : base(config)
        {
            var obj = BaseEntity.CreateEmptyInstance<TEntity>();
            tableName = obj.TableName;
            idKey = obj.IdKey;
            insertQuery = obj.InsertQuery;
            updateQuery = obj.UpdateQuery;
        }

        public bool Delete(int id)
        {
            using (var db = OpenConnection())
            {
                return db.Execute($@"delete from  {tableName} where {idKey} = @id", new { id })>0;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            using(var db = OpenConnection())
            {
                return db.Query<TEntity>($"select * from  {tableName}").ToList();
            }
        }

        public TEntity? GetById(int id)
        {
            using (var db = OpenConnection())
            {
                return db.Query<TEntity>($@"select * from  {tableName} where {idKey} = @id", new {id}).FirstOrDefault();
            }
        }

        public bool Insert(TEntity item)
        {
            using (var db = OpenConnection())
            {
                return db.Execute(insertQuery, item)>0;
            }
        }

        public bool Update(TEntity item)
        {
            using (var db = OpenConnection())
            {
                return db.Execute(updateQuery, item) > 0;
            }
        }
    }
}
