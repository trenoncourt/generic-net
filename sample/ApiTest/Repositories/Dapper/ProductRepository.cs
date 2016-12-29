using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using ApiTest.Data.Entities;
using ApiTest.Dto;
using Dapper;
using Dommel;
using GenericNet.Reflection.Property.Extensions;
using GenericNet.Repository.Dapper;

namespace ApiTest.Repositories.Dapper
{
    public class ProductRepository : Repository<SqlConnection, Product>, IProductRepository
    {
        public ProductRepository(IServiceProvider sp) : base(sp)
        {
        }

        public IEnumerable<dynamic> GetProductsProjection()
        {
            PropertyInfo pName = PropertyHelper<Product>.GetProperty(p => p.Name);
            PropertyInfo pColor = PropertyHelper<Product>.GetProperty(p => p.Color);
            return Connection.Query($"SELECT {pName.Name}, {pColor.Name} FROM {TableName}");
        }

        public IEnumerable<ProductDto> GetProductsDtoProjection()
        {
            return Connection.GetAll<ProductDto>();
        }
    }
}