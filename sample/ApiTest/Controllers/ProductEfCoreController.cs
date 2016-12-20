using System.Collections.Generic;
using ApiTest.Data;
using Microsoft.AspNetCore.Mvc;
using GenericNet.Repository.Abstractions;
using GenericNet.UnitOfWork.Abstractions;

namespace ApiTest.Controllers
{
    [Route("api/ProductEfCore")]
    public class ProductEfCoreController
    {
        private readonly IUnitOfWorkAsync<AdventureWorksContext> _unitOfWork;
        private readonly IRepository<AdventureWorksContext, Product> _repository;

        public ProductEfCoreController(IUnitOfWorkAsync<AdventureWorksContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Get()
        {
           return new OkObjectResult(_unitOfWork.Repository<Product>().Select());
        }
    }
}