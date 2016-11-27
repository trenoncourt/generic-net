using System.Threading;
using System.Threading.Tasks;
using GenericNet.DataContext.Abstractions;

namespace GenericNet.UnitOfWork.Abstractions
{
    public interface IUnitOfWorkAsync<TDataContextAsync> : IUnitOfWork<TDataContextAsync> where TDataContextAsync : IDataContextAsync
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}