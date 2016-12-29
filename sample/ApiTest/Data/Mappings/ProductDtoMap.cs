using ApiTest.Data.Entities;
using ApiTest.Dto;
using Dapper.FluentMap.Dommel.Mapping;

namespace ApiTest.Data.Mappings
{
    public class ProductDtoMap : DommelEntityMap<ProductDto>
    {
        public ProductDtoMap()
        {
            ToTable("SalesLT.Product");
        }
    }
}