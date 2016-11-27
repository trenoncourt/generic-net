using System;
using GenericNet.DataContext.Abstractions;

namespace GenericNet.UnitOfWork.Abstractions
{
    public interface IUnitOfWork<TDataContext> : IDisposable where TDataContext : IDataContext
    {
        int SaveChanges();
        void Dispose(bool disposing);
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
        bool Commit();
        void Rollback();
    }
}