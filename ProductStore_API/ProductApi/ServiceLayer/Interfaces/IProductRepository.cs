using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainLayer.Entities;
using System.Threading.Tasks;
using System.Reflection;

namespace ServiceLayer.Interfaces
{
    public interface IProductRepository
    {
        List<ProductEntity> GetAllProduct();

        Task<IEnumerable<ProductEntity>> Search(string name);
     
        ProductEntity GetProduct(int id);

        String AddProduct(ProductEntity product);

        String UpdateProduct(ProductEntity product);
        String DeleteProduct(int id);


    }
}
