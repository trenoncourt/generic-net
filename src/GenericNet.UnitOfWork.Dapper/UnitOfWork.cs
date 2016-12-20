using System;
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
        protected readonly TConnection Connection;
        protected readonly IServiceProvider ServiceProvider;
        protected IDbTransaction Transaction;

        public UnitOfWork(IServiceProvider serviceProvider)
        {
            Connection = serviceProvider.GetService(typeof(TConnection)) as TConnection;
            if (Connection == null)
            {
                throw new NullReferenceException(nameof(Connection));
            }
            ServiceProvider = serviceProvider;
            Connection.Open();
            //Transaction = Connection.BeginTransaction();
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
            return ServiceProvider.GetService(typeof(IRepository<TConnection, TEntity>)) as IRepository<TConnection, TEntity>;
        }

        public void Dispose()
        {
            Connection.Dispose();
        }
    }
}