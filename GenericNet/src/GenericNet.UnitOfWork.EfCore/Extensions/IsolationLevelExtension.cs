using System.Data;

namespace GenericNet.UnitOfWork.EfCore.Extensions
{
    public static class IsolationLevelExtension
    {
        public static IsolationLevel ToEfCoreIsolationLevel(this Abstractions.IsolationLevel isolationLevel)
        {
            return (IsolationLevel) isolationLevel;
        }
    }
}