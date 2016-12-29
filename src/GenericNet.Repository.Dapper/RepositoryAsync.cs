using GenericNet.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Dapper;

namespace GenericNet.Repository.Dapper
{
    public class RepositoryAsync<TConnection, TEntity> : Repository<TConnection, TEntity>, IRepositoryAsync<TConnection, TEntity>
        where TConnection : class, IDbConnection, new()
        where TEntity : class
    {
        public RepositoryAsync(IServiceProvider sp, string table = null) : base(sp)
        {
        }

        public virtual async Task<IEnumerable<TEntity>> SelectAsync(
            Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            int? skipPage = null,
            int? takePage = null,
            int? skip = null,
            int? take = null,
            bool tracking = false)
        {
            return Query(await Connection.QueryAsync<TEntity>($"SELECT * FROM {TableName}"));
        }

        public virtual async Task<IEnumerable<TResult>> SelectAsync<TResult>(
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
            return Query(await Connection.QueryAsync<TEntity>($"SELECT * FROM {TableName}")).Select(select.Compile());
        }

        public virtual Task<TEntity> FindAsync(params object[] keyValues)
        {
            SqlConnection sqlConnection = Connection as SqlConnection;
            if (sqlConnection != null)
            {
                return Connection.QueryFirstOrDefaultAsync<TEntity>($"SELECT TOP 1 FROM {TableName} WHERE id = @key", keyValues);
            }
            throw new NotImplementedException();
        }

        public virtual Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task<TEntity> FindFirstAsync(
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

        public virtual Task<TResult> FindFirstAsync<TResult>(
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

        public virtual Task<TEntity> FindLastAsync(
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

        public virtual Task<TResult> FindLastAsync<TResult>(
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
        
        public virtual Task<bool> DeleteAsync(object key)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> DeleteAsync(CancellationToken cancellationToken, object key)
        {
            throw new NotImplementedException();
        }
    }
}