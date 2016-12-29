using GenericNet.Service.Abstractions;
using GenericNet.Repository.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace GenericNet.Service
{
    public class Service<TIdentifier, TEntity> : IService<TIdentifier, TEntity>
        where TIdentifier : class
        where TEntity : class 
    {
        private readonly IRepository<TIdentifier, TEntity> _repository;

        protected Service(IRepository<TIdentifier, TEntity> repository) { _repository = repository; }

        public virtual TEntity Find(params object[] keyValues)
        {
            return _repository.Find(keyValues);
        }

        public IEnumerable<TEntity> Select(bool activateTracking = false)
        {
            return _repository.Select(activateTracking);
        }

        public virtual TEntity Insert(TEntity entity)
        {
            return _repository.Insert(entity);
        }

        public virtual void InsertRange(IEnumerable<TEntity> entities)
        {
            _repository.InsertRange(entities);
        }

        public virtual TEntity Update(TEntity entity)
        {
            return _repository.Update(entity);
        }

        public virtual void Delete(params object[] keyValues)
        {
            _repository.Delete(keyValues);
        }

        public virtual void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }

        public IQueryable<TEntity> Queryable(bool activateTracking = false)
        {
            return _repository.Queryable(activateTracking);
        }
    }
}