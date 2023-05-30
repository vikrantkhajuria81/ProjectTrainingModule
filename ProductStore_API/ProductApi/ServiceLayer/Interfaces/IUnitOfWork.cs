using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> SaveAsync();

        IProductRepository ProductRepository { get; }   
    }
}
