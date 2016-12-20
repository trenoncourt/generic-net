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

        public ProductController(IUnitOfWorkAsync<AdventureWorksContext> unitOfWork, IRepository<AdventureWorksContext, Product> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public IEnumerable<Product> Get()
        {
           return _unitOfWork.Repository<Product>().Select();
        }
    }
}