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
using Dommel;

namespace GenericNet.Repository.Dapper
{
    public class RepositoryAsync<TConnection, TEntity> : Repository<TConnection, TEntity>, IRepositoryAsync<TConnection, TEntity>
        where TConnection : class, IDbConnection, new()
        where TEntity : class
    {
        public RepositoryAsync(IServiceProvider sp) : base(sp)
        {
        }

        public virtual Task<TEntity> FindAsync(params object[] keyValues)
        {
            return Connection.GetAsync<TEntity>(keyValues);
        }

        public Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken)
        {
            return Connection.GetAsync<TEntity>(keyValues);
        }

        public virtual Task<IEnumerable<TEntity>> SelectAsync(bool tracking = false)
        {
            return Connection.GetAllAsync<TEntity>();
        }

        public virtual Task<bool> DeleteAsync(params object[] keyValues)
        {
            return Connection.DeleteAsync(keyValues);
        }

        public virtual Task<bool> DeleteAsync(object[] keyValues, CancellationToken cancellationToken)
        {
            return Connection.DeleteAsync(keyValues);
        }
    }
}