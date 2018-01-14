using Project_WebCoop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_WebCoop.Services
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }

        void AddNewProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);        
    }
}
