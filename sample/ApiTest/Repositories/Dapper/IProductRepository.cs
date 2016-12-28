using System.Data.SqlClient;
using ApiTest.Data;
using GenericNet.Repository.Abstractions;
using System.Collections.Generic;

namespace ApiTest.Repositories.Dapper
{
    public interface IProductRepository : IRepository<SqlConnection, Product>
    {
        IEnumerable<dynamic> GetProductsProjection();
    }
}