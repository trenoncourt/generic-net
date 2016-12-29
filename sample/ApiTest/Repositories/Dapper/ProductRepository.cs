using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using ApiTest.Data.Entities;
using ApiTest.Data.Tables;
using ApiTest.Dto;
using Dapper;
using Dommel;
using GenericNet.Reflection.Property.Extensions;
using GenericNet.Repository.Dapper;

namespace ApiTest.Repositories.Dapper
{
    public class ProductRepository : Repository<SqlConnection, Product>, IProductRepository
    {
        private readonly ProductTable _productTable;

        public ProductRepository(IServiceProvider sp, ProductTable productTable) : base(sp)
        {
            _productTable = productTable;
        }

        public IEnumerable<dynamic> GetProductsProjection()
        {
            return Connection.Query($"SELECT {_productTable.NameName}, {_productTable.ColorName} FROM {_productTable.TableName}");
        }

        public IEnumerable<ProductDto> GetProductsDtoProjection()
        {
            return Connection.GetAll<ProductDto>();
        }
    }
}