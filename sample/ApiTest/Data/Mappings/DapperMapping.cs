using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;

namespace ApiTest.Data.Mappings
{
    public static class DapperMapping
    {
        public static void Initialize()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new ProductMap());
                config.AddMap(new ProductDtoMap());
                config.ForDommel();
            });
        }
    }
}