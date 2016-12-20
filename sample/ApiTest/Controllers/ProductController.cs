using System.Collections.Generic;
using ApiTest.Data;
using Microsoft.AspNetCore.Mvc;
using GenericNet.Repository.Abstractions;
using GenericNet.UnitOfWork.Abstractions;

namespace ApiTest.Controllers
{
    [Route("api/products")]
    public class ProductController
    {
        private readonly IUnitOfWorkAsync<AdventureWorksContext> _unitOfWork;
        private readonly IRepository<AdventureWorksContext, Product> _repository;

        public ProductController(IUnitOfWorkAsync<AdventureWorksContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Get()
        {
           return new OkObjectResult(_unitOfWork.Repository<Product>().Select());
        }
    }
}