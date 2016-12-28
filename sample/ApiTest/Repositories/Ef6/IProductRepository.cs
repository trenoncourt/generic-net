using System.Collections.Generic;
using ApiTest.Data;
using GenericNet.Repository.Abstractions;

namespace ApiTest.Repositories.Ef6
{
    public interface IProductRepository : IRepository<AdventureWorksEf6Context, Product>
    {
        IEnumerable<dynamic> GetProductsProjection();
    }
}