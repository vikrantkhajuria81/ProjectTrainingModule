using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class ProductRepository : IProductRepository
    {

        private readonly ProductDbContext _dbContext;
        public ProductRepository(ProductDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        //Get ALL USer
        public List<ProductEntity> GetAllProduct()
        {
            return this._dbContext.ProductTable.ToList();
        }

        // GET SINGLE USER

        public ProductEntity GetProduct(int id)
        {
            return this._dbContext.ProductTable.Where(x => x.id == id).FirstOrDefault();
        }


        // ADD NEW USER

        public string AddProduct(ProductEntity product)
        {

            try
            {
                this._dbContext.ProductTable.Add(product);
                this._dbContext.SaveChanges();
                return "ok";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }

        // REMOVE USER
        public string DeleteProduct(int id)
        {

            try
            {
                var user = this._dbContext.ProductTable.Find(id);
                this._dbContext.Remove(user);
                this._dbContext.SaveChanges();
                return "Product removed";
            }

            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        // UPDATE USER

        public string UpdateProduct(ProductEntity product)
        {

            try
            {

                var ProductValue = _dbContext.ProductTable.Find(product.id);

                if (ProductValue != null)
                {
                    ProductValue.title = product.title;
                    ProductValue.discountPercentage = product.discountPercentage;
                    ProductValue.price = product.price;
                    ProductValue.description = product.description;
                    ProductValue.rating = product.rating;
                    ProductValue.stock = product.stock;
                    ProductValue.brand = product.brand;
                    ProductValue.category = product.category;
                    ProductValue.thumbnail = product.thumbnail;
                    this._dbContext.Update(ProductValue);
                    this._dbContext.SaveChanges();
                    return "updated";
                }

                else

                    return "No user found";

            }

            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        public async Task<IEnumerable<ProductEntity>> Search(string name)
        {
            IQueryable<ProductEntity> query = _dbContext.ProductTable;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.title.Contains(name));
                          
            }

            return await query.ToListAsync();
        }

    }
}
