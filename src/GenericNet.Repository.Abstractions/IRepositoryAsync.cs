using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GenericNet.Repository.Abstractions
{
    public interface IRepositoryAsync<TIdentifier, TEntity> : IRepository<TIdentifier, TEntity>
        where TIdentifier : class
        where TEntity : class
    {
        Task<TEntity> FindAsync(params object[] keyValues);

        Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken);

        Task<IEnumerable<TEntity>> SelectAsync(bool activateTracking = false);

        Task<bool> DeleteAsync(params object[] keyValues);

        Task<bool> DeleteAsync(object[] keyValues, CancellationToken cancellationToken);
    }
}