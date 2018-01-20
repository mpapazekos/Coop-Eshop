using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project_WebCoop.Data;
using Project_WebCoop.Models;

namespace Project_WebCoop.Services
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Product> Products => _context.Products.Include(prod => prod.ProductCategories)
                                                                .Include(prod => prod.SupplierProducts);

        public IQueryable<SupplierProduct> SupplierProducts => throw new NotImplementedException();

        public IQueryable<BasePrice> BasePrices => throw new NotImplementedException();

        public IQueryable<SalePrice> SalePrices => throw new NotImplementedException();

        public IQueryable<Category> Categories => throw new NotImplementedException();

        public IQueryable<ProductCategory> ProductCategories => throw new NotImplementedException();

        public void AddNewProduct(Product product)
        {
            _context.AttachRange(product.ProductCategories, product.SupplierProducts);
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        Product IProductRepository.AddNewProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
