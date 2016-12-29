using ApiTest.Data;
using ApiTest.Data.Contexts;
using ApiTest.Data.Entities;
using ApiTest.Repositories.Ef6;
using GenericNet.Repository.Abstractions;
using GenericNet.UnitOfWork.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    [Route("api/ProductEf6")]
    public class ProductEf6Controller
    {
        public IActionResult Get([FromServices] IUnitOfWorkAsync<AdventureWorksEf6Context> unitOfWork)
        {
            return new OkObjectResult(unitOfWork.Repository<Product>().Select());
        }

        [HttpGet("with_repository_injection")]
        public IActionResult GetWithRepositoryInjection([FromServices] IRepository<AdventureWorksEf6Context, Product> repository)
        {
            return new OkObjectResult(repository.Select());
        }

        [HttpGet("with_custom_repository")]
        public IActionResult GetWithCustomRepository([FromServices] IProductRepository repository)
        {
            return new OkObjectResult(repository.GetProductsProjection());
        }
    }
}