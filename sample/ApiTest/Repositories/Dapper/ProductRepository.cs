using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ApiTest.Data;
using Dapper;
using GenericNet.Repository.Dapper;

namespace ApiTest.Repositories.Dapper
{
    public class ProductRepository : Repository<SqlConnection, Product>, IProductRepository
    {
        public ProductRepository(IServiceProvider sp, string table = "SalesLT.Product") : base(sp, table)
        {
        }

        public IEnumerable<dynamic> GetProductsProjection()
        {
            return Connection.Query("SELECT name, color FROM SalesLT.Product");
        }
    }
}