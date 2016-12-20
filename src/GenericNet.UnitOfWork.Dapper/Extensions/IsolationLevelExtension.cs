using System.Data;

namespace GenericNet.UnitOfWork.Dapper.Extensions
{
    public static class IsolationLevelExtension
    {
        public static IsolationLevel ToDapperIsolationLevel(this Abstractions.IsolationLevel isolationLevel)
        {
            return (IsolationLevel) isolationLevel;
        }
    }
}