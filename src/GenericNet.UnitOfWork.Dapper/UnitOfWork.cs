using System.Data;
using GenericNet.Repository.Abstractions;
using GenericNet.UnitOfWork.Abstractions;
using GenericNet.UnitOfWork.Dapper.Extensions;
using IsolationLevel = GenericNet.UnitOfWork.Abstractions.IsolationLevel;

namespace GenericNet.UnitOfWork.Dapper
{
    public class UnitOfWork<TConnection> : IUnitOfWork<TConnection>
        where TConnection : class, IDbConnection, new()
    {
        protected IDbConnection Connection;
        protected IDbTransaction Transaction;

        public UnitOfWork(string connectionString)
        {
            Connection = new TConnection {ConnectionString = connectionString};
            Connection.Open();
            Transaction = Connection.BeginTransaction();
        }

        public void SaveChanges()
        {
            Transaction.Commit();
        }

        public virtual void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
        {
            Transaction = Connection.BeginTransaction(isolationLevel.ToDapperIsolationLevel());
        }

        public virtual void Commit()
        {
            Transaction.Commit();
        }

        public virtual void Rollback()
        {
            Transaction.Rollback();
        }

        public IRepository<TConnection, TEntity> Repository<TEntity>() where TEntity : class
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            Connection.Dispose();
        }
    }
}