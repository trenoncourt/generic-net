using ApiTest.Data;
using GenericNet.Repository.Abstractions;
using GenericNet.UnitOfWork.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ApiTest.Controllers
{
    [Route("api/ProductDapper")]
    public class ProductDapperController
    {
        private readonly IUnitOfWorkAsync<SqlConnection> _unitOfWork;
        private readonly IRepository<SqlConnection, Product> _repository;

        public ProductDapperController(IUnitOfWorkAsync<SqlConnection> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Get()
        {
            return new OkObjectResult(_unitOfWork.Repository<Product>().Select());
        }
    }
}
