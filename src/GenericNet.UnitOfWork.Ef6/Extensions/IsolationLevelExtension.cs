using IsolationLevel = System.Data.IsolationLevel;

namespace GenericNet.UnitOfWork.Ef6.Extensions
{
    public static class IsolationLevelExtension
    {
        public static IsolationLevel ToEfCoreIsolationLevel(this Abstractions.IsolationLevel isolationLevel)
        {
            return (IsolationLevel) isolationLevel;
        }
    }
}