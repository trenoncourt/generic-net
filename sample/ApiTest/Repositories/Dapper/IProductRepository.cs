using System.Data.SqlClient;
using GenericNet.Repository.Abstractions;
using System.Collections.Generic;
using ApiTest.Data.Entities;
using ApiTest.Dto;

namespace ApiTest.Repositories.Dapper
{
    public interface IProductRepository : IRepository<SqlConnection, Product>
    {
        IEnumerable<dynamic> GetProductsProjection();

        IEnumerable<ProductDto> GetProductsDtoProjection();
    }
}