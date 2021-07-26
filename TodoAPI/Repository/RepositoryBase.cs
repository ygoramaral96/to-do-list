using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq.Expressions;
using Dommel;
using TodoApi.Models;

namespace TodoApi.Repository
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {

        protected DbSession _db;
        protected RepositoryBase(DbSession dbSession)
        {
            _db = dbSession;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            using (var db = _db.Connection)
            {
                return db.GetAll<TEntity>();
            }
        }

        public async virtual TEntity GetById(int id)
        {
            using (var db = _db.Connection)
            {
                return await db.GetAsync<TEntity>(id);
            }
        }

        public async virtual void Insert(ref TEntity entity)
        {
            using (var db = _db.Connection)
            {
                var id = await db.InsertAsync(entity);

                entity = GetById(id);
            }
        }

        public virtual bool Update(TEntity entity)
        {
            using (var db = _db.Connection)
            {
                return db.Update(entity);
            }
        }

        public virtual bool Delete(Int32 id)
        {
            using (var db = _db.Connection)
            {
                var entity = GetById(id);

                if (entity == null) throw new Exception("Registro não encontrado");

                return db.Delete(entity);
            }
        }

        public virtual IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            using (var db = _db.Connection)
            {
                return db.Select(predicate);
            }
        }
    }
}
