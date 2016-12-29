using ApiTest.Data.Entities;
using Dommel;
using GenericNet.Reflection.Property.Extensions;

namespace ApiTest.Data.Tables
{
    public class ProductTable : ITable
    {
        public string TableName { get; } = DommelMapper.Resolvers.Table(typeof(Product));

        public string NameName { get; } = DommelMapper.Resolvers.Column(PropertyHelper<Product>.GetProperty(p => p.Name));

        public string ColorName { get; } = DommelMapper.Resolvers.Column(PropertyHelper<Product>.GetProperty(p => p.Color));
    }
}