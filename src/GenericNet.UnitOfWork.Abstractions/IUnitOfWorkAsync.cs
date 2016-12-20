using System.Threading;
using System.Threading.Tasks;
using GenericNet.Repository.Abstractions;

namespace GenericNet.UnitOfWork.Abstractions
{
    public interface IUnitOfWorkAsync<TIdentifier> : IUnitOfWork<TIdentifier> where TIdentifier : class
    {
        Task SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        IRepositoryAsync<TIdentifier, TEntity> RepositoryAsync<TEntity>() where TEntity : class;
    }
}