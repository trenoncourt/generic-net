using System;
using GenericNet.DataContext.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace GenericNet.DataContext
{
    public class DataContext : DbContext, IDataContextAsync
    {
        public DataContext()
        {
            InstanceId = Guid.NewGuid();
        }

        public DataContext(DbContextOptions options) : base(options)
        {
            InstanceId = Guid.NewGuid();
        }

        public Guid InstanceId { get; }
    }
}