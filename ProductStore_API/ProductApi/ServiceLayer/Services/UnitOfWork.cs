using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services 
{
    public class UnitOfWork : IUnitOfWork
    {

        public UnitOfWork(ProductDbContext dbContext) {

            Context = dbContext;
        } 

        public ProductDbContext Context { get; }

        public IProductRepository ProductRepository => new ProductRepository(Context);


        public async Task<bool> SaveAsync()
        {
            try
            {
                return await Context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

