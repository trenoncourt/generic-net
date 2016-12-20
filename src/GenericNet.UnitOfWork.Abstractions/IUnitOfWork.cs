using System;
using GenericNet.Repository.Abstractions;

namespace GenericNet.UnitOfWork.Abstractions
{
    public interface IUnitOfWork<TIdentifier> : IDisposable where TIdentifier : class
    {
        void SaveChanges();
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
        void Commit();
        void Rollback();
        IRepository<TIdentifier, TEntity> Repository<TEntity>() where TEntity : class;
    }
}