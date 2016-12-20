using System;
using System.Data;
using GenericNet.Repository.Abstractions;
using GenericNet.UnitOfWork.Abstractions;
using GenericNet.UnitOfWork.EfCore.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using IsolationLevel = GenericNet.UnitOfWork.Abstractions.IsolationLevel;

namespace GenericNet.UnitOfWork.EfCore
{
    public class UnitOfWork<TIdentifier> : DbContext, IUnitOfWork<TIdentifier> where TIdentifier : class
    {
        protected readonly IServiceProvider ServiceProvider;
        protected IDbConnection Connection;
        protected IDbTransaction Transaction;

        public UnitOfWork(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public virtual void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
        {
            Connection = Database.GetDbConnection();
            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }

            Transaction = Connection.BeginTransaction(isolationLevel.ToEfCoreIsolationLevel());
        }

        public virtual void Commit()
        {
            Transaction.Commit();
        }

        public virtual void Rollback()
        {
            Transaction.Rollback();
        }

        public IRepository<TIdentifier, TEntity> Repository<TEntity>() where TEntity : class
        {
            return ServiceProvider.GetService<IRepository<TIdentifier, TEntity>>();
        }
    }
}