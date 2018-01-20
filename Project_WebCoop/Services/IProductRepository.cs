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
        IQueryable<SupplierProduct> SupplierProducts { get; } 
        
        IQueryable<BasePrice> BasePrices { get;}
        IQueryable<SalePrice> SalePrices { get;}

        IQueryable<Category> Categories { get; }
        IQueryable<ProductCategory> ProductCategories { get; }


        void AddNewProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);        
    }
}
