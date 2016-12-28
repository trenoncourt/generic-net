using System.Collections.Generic;
using System.Linq;
using ApiTest.Data;
using GenericNet.Repository.Ef6;

namespace ApiTest.Repositories.Ef6
{
    public class ProductRepository : Repository<AdventureWorksEf6Context, Product>, IProductRepository
    {
        public ProductRepository(AdventureWorksEf6Context context) : base(context)
        {
        }


        public IEnumerable<dynamic> GetProductsProjection()
        {
            return Queryable().Select(p => new {p.Name, p.Color});
        }
    }
}