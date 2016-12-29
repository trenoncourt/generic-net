using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using ApiTest.Data.Entities;
using ApiTest.Dto;
using Dapper;
using Dommel;
using GenericNet.Repository.Dapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApiTest.Repositories.Dapper
{
    public class ProductRepository : Repository<SqlConnection, Product>, IProductRepository
    {
        public ProductRepository(IServiceProvider sp) : base(sp)
        {
        }

        public IEnumerable<dynamic> GetProductsProjection()
        {
            return Connection.Query($"SELECT name, color FROM {TableName}");
        }

        public IEnumerable<ProductDto> GetProductsDtoProjection()
        {
            return Connection.GetAll<ProductDto>();
        }
    }
}