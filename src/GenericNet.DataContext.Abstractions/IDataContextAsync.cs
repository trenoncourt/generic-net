using System.Threading;
using System.Threading.Tasks;

namespace GenericNet.DataContext.Abstractions
{
    public interface IDataContextAsync : IDataContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}