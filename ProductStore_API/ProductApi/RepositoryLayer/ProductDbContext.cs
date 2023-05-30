using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using DomainLayer.Entities;
using System.Reflection.Emit;

namespace RepositoryLayer
{
        public class ProductDbContext : DbContext
        {
            public ProductDbContext() : base() { }
            public ProductDbContext(DbContextOptions<ProductDbContext> options)
                : base(options)
            {
            }
            public DbSet <ProductEntity> ProductTable { get; set; }


            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
            }
        }
    }