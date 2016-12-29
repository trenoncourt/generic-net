using System.Collections.Generic;
using ApiTest.Data;
using ApiTest.Data.Contexts;
using ApiTest.Data.Entities;
using GenericNet.Repository.Abstractions;

namespace ApiTest.Repositories.Ef6
{
    public interface IProductRepository : IRepository<AdventureWorksEf6Context, Product>
    {
        IEnumerable<dynamic> GetProductsProjection();
    }
}