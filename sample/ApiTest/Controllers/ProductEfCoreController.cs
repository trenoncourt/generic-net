﻿using ApiTest.Data;
using ApiTest.Data.Contexts;
using ApiTest.Data.Entities;
using ApiTest.Repositories.EfCore;
using Microsoft.AspNetCore.Mvc;
using GenericNet.Repository.Abstractions;
using GenericNet.UnitOfWork.Abstractions;

namespace ApiTest.Controllers
{
    [Route("api/ProductEfCore")]
    public class ProductEfCoreController
    {
        public IActionResult Get([FromServices] IUnitOfWorkAsync<AdventureWorksEfCoreContext> unitOfWork)
        {
           return new OkObjectResult(unitOfWork.Repository<Product>().Select());
        }

        [HttpGet("with_repository_injection")]
        public IActionResult GetWithRepositoryInjection([FromServices] IRepository<AdventureWorksEfCoreContext, Product> repository)
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