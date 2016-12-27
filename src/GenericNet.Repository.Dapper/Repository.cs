using GenericNet.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace GenericNet.Repository.Dapper
{
    public class Repository<TConnection, TEntity> : IRepository<TConnection, TEntity>
        where TConnection : class, IDbConnection, new()
        where TEntity : class
    {
        protected readonly TConnection Connection;
        private readonly string _table;

        public Repository(TConnection connection, string table = null)
        {
            Connection = connection;
            _table = table;
        }

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
            string tableName = _table ?? typeof(TEntity).Name;
            return Connection.Query<TEntity>($"SELECT * FROM {tableName}");
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
            throw new NotImplementedException();
        }

        public virtual TEntity Find(params object[] key)
        {
            SqlConnection sqlConnection = Connection as SqlConnection;
            if (sqlConnection != null)
            {
                return Connection.QueryFirstOrDefault<TEntity>($"SELECT TOP 1 FROM {nameof(TEntity)}");
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
    }
}