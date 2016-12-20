using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using GenericNet.Repository.Abstractions;
using GenericNet.UnitOfWork.Abstractions;

namespace GenericNet.UnitOfWork.Dapper
{
    public class UnitOfWorkAsync<TConnection> : UnitOfWork<TConnection>, IUnitOfWorkAsync<TConnection>
        where TConnection : class, IDbConnection, new()
    {
        public UnitOfWorkAsync(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Factory.StartNew(SaveChanges, cancellationToken);
        }

        public IRepositoryAsync<TConnection, TEntity> RepositoryAsync<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }
    }
}
