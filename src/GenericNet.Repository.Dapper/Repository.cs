using GenericNet.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data;
using System.Data.SqlClient;
using Dapper;
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
        private readonly string _table;

        public Repository(IServiceProvider sp, string table = null)
        {
            Connection = sp.GetService<TConnection>();
            Logger = sp.GetService<ILogger<Repository<TConnection, TEntity>>>();
            _table = table;
        }

        public string TableName => _table ?? typeof(TEntity).Name;

        public virtual IEnumerable<TEntity> Select(
            Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            int? skipPage = null,
            int? takePage = null,
            int? skip = null,
            int? take = null,
            bool tracking = false)
        {
            return Query(Connection.Query<TEntity>($"SELECT * FROM {TableName}"));
        }

        public virtual IEnumerable<TResult> Select<TResult>(
            Expression<Func<TEntity, TResult>> select,
            Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            int? skipPage = null,
            int? takePage = null,
            int? skip = null,
            int? take = null,
            bool tracking = false)
        {
            return Query(Connection.Query<TEntity>($"SELECT * FROM {TableName}")).Select(select.Compile());
        }

        public virtual TEntity Find(params object[] key)
        {
            SqlConnection sqlConnection = Connection as SqlConnection;
            if (sqlConnection != null)
            {
                return Connection.QueryFirstOrDefault<TEntity>($"SELECT TOP 1 FROM {TableName} WHERE id = @key", key);
            }
            throw new NotImplementedException();
        }

        public virtual TEntity FindFirst(
            Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            int? skipPage = null,
            int? takePage = null,
            int? skip = null,
            int? take = null,
            bool tracking = false)
        {
            throw new NotImplementedException();
        }

        public virtual TResult FindFirst<TResult>(
            Expression<Func<TEntity, TResult>> select,
            Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            int? skipPage = null,
            int? takePage = null,
            int? skip = null,
            int? take = null,
            bool tracking = false)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity FindLast(
            Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            int? skipPage = null,
            int? takePage = null,
            int? skip = null,
            int? take = null,
            bool tracking = false)
        {
            throw new NotImplementedException();
        }
        public virtual TResult FindLast<TResult>(
            Expression<Func<TEntity, TResult>> select,
            Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            int? skipPage = null,
            int? takePage = null,
            int? skip = null,
            int? take = null,
            bool tracking = false)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void InsertRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<TEntity> Queryable()
        {
            throw new NotImplementedException();
        }

        protected IEnumerable<TEntity> Query(
            IEnumerable<TEntity> query,
            Func<TEntity, bool> where = null,
            Func<IEnumerable<TEntity>, IOrderedEnumerable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            int? skipPage = null,
            int? takePage = null,
            int? skip = null,
            int? take = null,
            bool tracking = false)
        {
            if (includes != null)
            {
                Logger.LogWarning("Include is not supported in Dapper queries in this release.");
            }
            if (orderBy != null)
            {
                Logger.LogWarning("OrderBy is evaluated after database get in this release");
                query = orderBy(query);
            }
            if (skipPage != null && takePage != null)
            {
                Logger.LogWarning("Skip & Take are evaluated after database get in this release");
                query = query.Skip((skipPage.Value - 1) * takePage.Value).Take(takePage.Value);
            }
            if (skip != null)
            {
                Logger.LogWarning("Skip is evaluated after database get in this release");
                query = query.Skip(skip.Value - 1);
            }
            if (take != null)
            {
                Logger.LogWarning("Take is evaluated after database get in this release");
                query = query.Take(take.Value);
            }
            if (where != null)
            {
                Logger.LogWarning("Where is evaluated after database get in this release");
                query = query.Where(where);
            }
            return query;
        }
    }
}