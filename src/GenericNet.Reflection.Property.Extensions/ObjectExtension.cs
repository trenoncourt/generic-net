using System;
using System.Linq.Expressions;
using System.Reflection;

namespace GenericNet.Reflection.Property.Extensions
{
    public static class ObjectExtension
    {
        public static PropertyInfo GetProperty<T, TValue>(this T obj, Expression<Func<T, TValue>> selector)
        {
            Expression body = selector;
            if (body is LambdaExpression)
            {
                body = ((LambdaExpression)body).Body;
            }
            switch (body.NodeType)
            {
                case ExpressionType.MemberAccess:
                    return (PropertyInfo)((MemberExpression)body).Member;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}