using ApiTest.Data;
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
    }
}