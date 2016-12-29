using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using GenericNet.Repository.Abstractions;
using GenericNet.Service.Abstractions;

namespace GenericNet.Service
{
    public class ServiceAsync<TIdentifier, TEntity> : Service<TIdentifier, TEntity>, IServiceAsync<TIdentifier, TEntity>
        where TIdentifier : class
        where TEntity : class
    {
        private readonly IRepositoryAsync<TIdentifier, TEntity> _repository;

        public ServiceAsync(IRepositoryAsync<TIdentifier, TEntity> repository) : base(repository)
        {
            _repository = repository;
        }

        public virtual async Task<TEntity> FindAsync(params object[] keyValues)
        {
            return await _repository.FindAsync(keyValues);
        }

        public virtual async Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken)
        {
            return await _repository.FindAsync(cancellationToken, keyValues);
        }

        public virtual async Task<IEnumerable<TEntity>> SelectAsync(bool activateTracking = false)
        {
            return await _repository.SelectAsync(activateTracking);
        }

        public virtual async Task<bool> DeleteAsync(params object[] keyValues)
        {
            return await _repository.DeleteAsync(keyValues);
        }

        public virtual async Task<bool> DeleteAsync(object[] keyValues, CancellationToken cancellationToken)
        {
            return await _repository.DeleteAsync(cancellationToken, keyValues);
        }
    }
}