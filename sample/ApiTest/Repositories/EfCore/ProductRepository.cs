using System.Collections.Generic;
using System.Linq;
using ApiTest.Data;
using GenericNet.Repository.EfCore;

namespace ApiTest.Repositories.EfCore
{
    public class ProductRepository : Repository<AdventureWorksContext, Product>, IProductRepository
    {
        public ProductRepository(AdventureWorksContext context) : base(context)
        {
        }


        public IEnumerable<dynamic> GetProductsProjection()
        {
            return Queryable().Select(p => new {p.Name, p.Color});
        }
    }
}