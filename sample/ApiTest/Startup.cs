﻿using System;
using ApiTest.Data;
using GenericNet.Repository.Abstractions;
using GenericNet.Repository.Dapper;
using GenericNet.UnitOfWork.Abstractions;
using GenericNet.UnitOfWork.EfCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Data.SqlClient;
using ApiTest.Data.Contexts;
using ApiTest.Data.Entities;
using ApiTest.Data.Mappings;
using ApiTest.Data.Tables;
using ApiTest.Repositories.Dapper;
using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;

namespace ApiTest
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            /** TODO : Add your connection string with user secrets (or in appsettings.json) :
             * 
             *  {
             *    "ConnectionStrings": {
             *      "GenericNetDb": "..."
             *    }
             *  }
             **/
            if (env.IsDevelopment())
            {
                builder.AddUserSecrets();
            }
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddJsonFormatters(settings =>
                {
                    settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    settings.DefaultValueHandling = DefaultValueHandling.Ignore;
                });
            DapperMapping.Initialize();

            services.AddSingleton<ProductTable>()

            .AddScoped(provider => new AdventureWorksEfCoreContext(provider, new DbContextOptionsBuilder().UseSqlServer(Configuration.GetConnectionString("GenericNetDb")).Options))
            .AddScoped(provider => new AdventureWorksEf6Context(provider, Configuration.GetConnectionString("GenericNetDb")))

            .AddScoped<IUnitOfWorkAsync<AdventureWorksEfCoreContext>>(provider => provider.GetService<AdventureWorksEfCoreContext>())
            .AddScoped<IUnitOfWorkAsync<AdventureWorksEf6Context>>(provider => provider.GetService<AdventureWorksEf6Context>())

            .AddScoped<IRepository<AdventureWorksEfCoreContext, Product>, GenericNet.Repository.EfCore.Repository<AdventureWorksEfCoreContext, Product>>()
            .AddScoped<IRepository<AdventureWorksEf6Context, Product>, GenericNet.Repository.Ef6.Repository<AdventureWorksEf6Context, Product>>()

            .AddScoped(provider => new SqlConnection(Configuration.GetConnectionString("GenericNetDb")))
            .AddScoped<IUnitOfWorkAsync<SqlConnection>>(provider => new GenericNet.UnitOfWork.Dapper.UnitOfWorkAsync<SqlConnection>(provider))
            .AddScoped<IRepository<SqlConnection, Product>, Repository<SqlConnection,Product>>()
            .AddScoped<IProductRepository, ProductRepository>()
            .AddScoped<Repositories.EfCore.IProductRepository, Repositories.EfCore.ProductRepository>()
            .AddScoped<Repositories.Ef6.IProductRepository, Repositories.Ef6.ProductRepository>();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            app.UseMvc();
        }
    }
}
