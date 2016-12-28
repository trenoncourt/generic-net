﻿using ApiTest.Data;
using Microsoft.AspNetCore.Mvc;
using GenericNet.Repository.Abstractions;
using GenericNet.UnitOfWork.Abstractions;

namespace ApiTest.Controllers
{
    [Route("api/ProductEfCore")]
    public class ProductEfCoreController
    {
        public IActionResult Get([FromServices] IUnitOfWorkAsync<AdventureWorksContext> unitOfWork)
        {
           return new OkObjectResult(unitOfWork.Repository<Product>().Select());
        }

        [HttpGet("with_repository_injection")]
        public IActionResult GetWithRepositoryInjection([FromServices] IRepository<AdventureWorksContext, Product> repository)
        {
           return new OkObjectResult(repository.Select());
        }
    }
}