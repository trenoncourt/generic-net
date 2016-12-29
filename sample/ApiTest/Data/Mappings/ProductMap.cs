using ApiTest.Data.Entities;
using Dapper.FluentMap.Dommel.Mapping;
using Dapper.FluentMap.Mapping;

namespace ApiTest.Data.Mappings
{
    public class ProductMap : DommelEntityMap<Product>
    {
        public ProductMap()
        {
            ToTable("SalesLT.Product");
        }
    }
}