﻿using System.Collections.Generic;
using ApiTest.Data;
using GenericNet.Repository.Abstractions;

namespace ApiTest.Repositories.EfCore
{
    public interface IProductRepository : IRepository<AdventureWorksContext, Product>
    {
        IEnumerable<dynamic> GetProductsProjection();
    }
}