using System;
using System.Threading;
using System.Threading.Tasks;
using GenericNet.Repository.Abstractions;
using GenericNet.UnitOfWork.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace GenericNet.UnitOfWork.Ef6
{
    public class UnitOfWorkAsync<TIdentifier> : UnitOfWork<TIdentifier>, IUnitOfWorkAsync<TIdentifier> where TIdentifier : class
    {
        public UnitOfWorkAsync(IServiceProvider serviceProvider, string nameOrConnectionString) : base(serviceProvider, nameOrConnectionString)
        {
        }

        public new async Task SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            await base.SaveChangesAsync(cancellationToken);
        }

        public IRepositoryAsync<TIdentifier, TEntity> RepositoryAsync<TEntity>() where TEntity : class
        {
            return ServiceProvider.GetService<IRepositoryAsync<TIdentifier, TEntity>>();
        }
    }
}