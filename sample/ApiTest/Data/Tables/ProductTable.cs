using ApiTest.Data.Entities;
using Dommel;
using GenericNet.Reflection.Property.Extensions;

namespace ApiTest.Data.Tables
{
    public class ProductTable : ITable
    {
        public string TableName => DommelMapper.Resolvers.Table(typeof(Product));

        public string NameName => DommelMapper.Resolvers.Column(PropertyHelper<Product>.GetProperty(p => p.Name));

        public string ColorName => DommelMapper.Resolvers.Column(PropertyHelper<Product>.GetProperty(p => p.Color));
    }
}