using System;

namespace GenericNet.DataContext.Abstractions
{
    public interface IDataContext : IDisposable
    {
        int SaveChanges();
    }
}