using GenericNet.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Dommel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GenericNet.Repository.Dapper
{
    public class Repository<TConnection, TEntity> : IRepository<TConnection, TEntity>
        where TConnection : class, IDbConnection, new()
        where TEntity : class
    {
        protected readonly TConnection Connection;
        protected readonly ILogger Logger;

        public Repository(IServiceProvider sp)
        {
            Connection = sp.GetService<TConnection>();
            Logger = sp.GetService<ILogger<Repository<TConnection, TEntity>>>();
        }

        public virtual TEntity Find(params object[] key)
        {
            return Connection.Get<TEntity>(key);
        }

        public virtual IEnumerable<TEntity> Select(bool tracking = false)
        {
            return Connection.GetAll<TEntity>();
        }

        public virtual TEntity Insert(TEntity entity)
        {
            return Connection.Insert(entity) as TEntity;
        }

        public virtual void InsertRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Connection.Insert(entity);
            }
        }

        public virtual TEntity Update(TEntity entity)
        {
            Connection.Update(entity);
            return entity;
        }

        public virtual void Delete(params object[] keyValues)
        {
            var entity = Find(keyValues);
            Connection.Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            Connection.Delete(entity);
        }

        public virtual IQueryable<TEntity> Queryable(bool activateTracking = false)
        {
            Logger.LogWarning("Dapper impl does not support IQueryable. Query will be evaluated after database fetch");
            return Connection.GetAll<TEntity>().AsQueryable();
        }
    }
}