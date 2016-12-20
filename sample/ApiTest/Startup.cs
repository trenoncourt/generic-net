﻿using ApiTest.Data;
using GenericNet.Repository.Abstractions;
using GenericNet.Repository.EfCore;
using GenericNet.UnitOfWork.Abstractions;
using GenericNet.UnitOfWork.EfCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddEntityFramework()
                .AddDbContext<AdventureWorksContext>(options => options.UseSqlServer("Server=tcp:trenoncourttest.database.windows.net,1433;Initial Catalog=AdventureWorks;Persist Security Info=False;User ID=trenoncourt;Password=Amour1105//0;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
            services.AddScoped<IUnitOfWorkAsync<AdventureWorksContext>, UnitOfWorkAsync<AdventureWorksContext>>();
            services.AddScoped<IRepository<AdventureWorksContext, Product>, Repository<AdventureWorksContext, Product>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
