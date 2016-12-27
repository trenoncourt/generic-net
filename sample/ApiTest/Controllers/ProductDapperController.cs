using System.Data.SqlClient;
using ApiTest.Data;
using GenericNet.Repository.Abstractions;
using GenericNet.UnitOfWork.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    [Route("api/ProductDapper")]
    public class ProductDapperController
    {
        public IActionResult Get([FromServices] IUnitOfWorkAsync<SqlConnection> unitOfWork)
        {
            return new OkObjectResult(unitOfWork.Repository<Product>().Select());
        }

        [HttpGet("with_repository_injection")]
        public IActionResult GetWithRepositoryInjection([FromServices] IRepository<SqlConnection, Product> repository)
        {
            return new OkObjectResult(repository.Select());
        }
    }
}
