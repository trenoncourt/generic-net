using System;
using System.Data.Entity;
using GenericNet.UnitOfWork.Ef6;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ApiTest.Data
{
    public class AdventureWorksEf6Context : UnitOfWorkAsync<AdventureWorksEf6Context>
    {
        public AdventureWorksEf6Context(IServiceProvider serviceProvider, string nameOrConnectionString) : base(serviceProvider, nameOrConnectionString)
        {
            var logger = serviceProvider.GetService<ILogger<AdventureWorksEfCoreContext>>();
            Database.Log = s => logger.LogDebug(s);
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerAddress>()
                .HasKey(ca => new {ca.AddressId, ca.CustomerId});

            modelBuilder.Entity<SalesOrderHeader> ()
                .HasKey(ca => ca.SalesOrderId);

            modelBuilder.Entity<ProductModelProductDescription> ()
                .HasKey(ca => new {ca.ProductModelId, ca.ProductDescriptionId, ca.Culture});

            modelBuilder.Entity<BuildVersion> ()
                .HasKey(ca => ca.SystemInformationId);

            modelBuilder.Entity<Address>()
                .HasMany(e => e.CustomerAddress)
                .WithRequired(e => e.Address)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Address>()
                .HasMany(e => e.SalesOrderHeaderBillToAddress)
                .WithOptional(e => e.BillToAddress)
                .HasForeignKey(e => e.BillToAddressId);

            modelBuilder.Entity<Address>()
                .HasMany(e => e.SalesOrderHeaderShipToAddress)
                .WithOptional(e => e.ShipToAddress)
                .HasForeignKey(e => e.ShipToAddressId);

            modelBuilder.Entity<Customer>()
                .Property(e => e.PasswordHash)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.PasswordSalt)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.CustomerAddress)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.SalesOrderHeader)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .ToTable("Product", "SalesLT");

            modelBuilder.Entity<Product>()
                .Property(e => e.StandardCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.ListPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.Weight)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.SalesOrderDetail)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductCategory>()
                .ToTable("ProductCategory", "SalesLT");

            modelBuilder.Entity<ProductCategory>()
                .HasMany(e => e.InverseParentProductCategory)
                .WithOptional(e => e.ParentProductCategory)
                .HasForeignKey(e => e.ParentProductCategoryId);

            modelBuilder.Entity<ProductDescription>()
                .ToTable("ProductDescription", "SalesLT");

            modelBuilder.Entity<ProductDescription>()
                .HasMany(e => e.ProductModelProductDescription)
                .WithRequired(e => e.ProductDescription)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductModel>()
                .ToTable("ProductModel", "SalesLT");

            modelBuilder.Entity<ProductModel>()
                .HasMany(e => e.ProductModelProductDescription)
                .WithRequired(e => e.ProductModel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductModelProductDescription>()
                .ToTable("ProductModelProductDescription", "SalesLT");

            modelBuilder.Entity<ProductModelProductDescription>()
                .Property(e => e.Culture)
                .IsFixedLength();

            modelBuilder.Entity<SalesOrderDetail>()
                .ToTable("SalesOrderDetail", "SalesLT");

            modelBuilder.Entity<SalesOrderDetail>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesOrderDetail>()
                .Property(e => e.UnitPriceDiscount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesOrderDetail>()
                .Property(e => e.LineTotal)
                .HasPrecision(38, 6);

            modelBuilder.Entity<SalesOrderHeader>()
                .ToTable("SalesOrderHeader", "SalesLT");

            modelBuilder.Entity<SalesOrderHeader>()
                .Property(e => e.CreditCardApprovalCode)
                .IsUnicode(false);

            modelBuilder.Entity<SalesOrderHeader>()
                .Property(e => e.SubTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesOrderHeader>()
                .Property(e => e.TaxAmt)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesOrderHeader>()
                .Property(e => e.Freight)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesOrderHeader>()
                .Property(e => e.TotalDue)
                .HasPrecision(19, 4);
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<BuildVersion> BuildVersion { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddress { get; set; }
        public virtual DbSet<ErrorLog> ErrorLog { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ProductDescription> ProductDescription { get; set; }
        public virtual DbSet<ProductModel> ProductModel { get; set; }
        public virtual DbSet<ProductModelProductDescription> ProductModelProductDescription { get; set; }
        public virtual DbSet<SalesOrderDetail> SalesOrderDetail { get; set; }
        public virtual DbSet<SalesOrderHeader> SalesOrderHeader { get; set; }
    }
}