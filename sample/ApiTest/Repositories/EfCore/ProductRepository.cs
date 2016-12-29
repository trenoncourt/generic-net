using System.Collections.Generic;
using System.Linq;
using ApiTest.Data;
using ApiTest.Data.Contexts;
using ApiTest.Data.Entities;
using GenericNet.Repository.EfCore;

namespace ApiTest.Repositories.EfCore
{
    public class ProductRepository : Repository<AdventureWorksEfCoreContext, Product>, IProductRepository
    {
        public ProductRepository(AdventureWorksEfCoreContext context) : base(context)
        {
        }


        public IEnumerable<dynamic> GetProductsProjection()
        {
            return Queryable().Select(p => new {p.Name, p.Color});
        }
    }
}