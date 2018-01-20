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

        public ProductRepository(ApplicationDbContext context) => _context = context;
    


        public IEnumerable<Product> Products => _context.Products.Include(prod => prod.ProductCategories)
                                                                .Include(prod => prod.SupplierProducts);

        public IEnumerable<SupplierProduct> SupplierProducts => _context.SupplierProducts.Include(sp => sp.BasePrices)
                                                                                        .Include(sp => sp.Supplier);

        public IEnumerable<BasePrice> BasePrices => _context.BasePrices.Include(bp => bp.SupplierProduct);

        public IEnumerable<SalePrice> SalePrices => _context.SalePrices.Include(bp => bp.SupplierProduct);

        public IEnumerable<Category> Categories => _context.Categories.Include(c => c.ProductCategories);

        public IEnumerable<ProductCategory> ProductCategories => _context.ProductCategories.Include(pc => pc.Product)
                                                                                          .Include(pc => pc.Category);


        public void StoreNewProduct(Product product)
        {
            _context.AttachRange(product.ProductCategories, product.SupplierProducts);
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void StoreNewSalePrice(SalePrice salePrice)
        {
            _context.AttachRange(salePrice.SupplierProduct);
            _context.SalePrices.Add(salePrice);
            _context.SaveChanges();
        }

        public void StoreNewSupplierProduct(SupplierProduct supplierProduct)
        {
            _context.AttachRange(supplierProduct.Product, supplierProduct.Supplier);
            _context.SupplierProducts.Add(supplierProduct);
            _context.SaveChanges();
        }

        public void StoreNewBasePrice(BasePrice basePrice)
        {
            _context.AttachRange(basePrice.SupplierProduct);
            _context.BasePrices.Add(basePrice);
            _context.SaveChanges();
        }

        public void StoreNewCategory(Category category)
        {
            _context.AttachRange(category.ProductCategories);
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        

        public Category GetCategoryByName(string categoryName)
        {
            return Categories.SingleOrDefault(c => c.CategoryName == categoryName);
        }

        public IEnumerable<ApplicationUser> GetCurrentSuppliers()
        {
            return SupplierProducts.Select(sp => sp.Supplier).Distinct();
        }

        public IEnumerable<SupplierProduct> GetLiveProducts()
        {
            return SupplierProducts.Where(sp => sp.IsLive == true);
        }

        public Product GetProductById(int productId)
        {
            return Products.SingleOrDefault(p => p.ProductID == productId);
        }

        public IEnumerable<SupplierProduct> FindByName(string productName)
        {
            return SupplierProducts.Where(sp => sp.Product.Name.Contains(productName));
        }

        public IEnumerable<SupplierProduct> GetProductsInCategory(string categoryName)
        {
           
            return from sp in SupplierProducts
                   join p in Products on sp.ProductID equals p.ProductID
                   join pc in ProductCategories on p.ProductID equals pc.ProductID
                   where pc.Category.CategoryName == categoryName
                   select new SupplierProduct
                   {
                       Supplier = sp.Supplier,
                       Product = p,
                       BasePrices = sp.BasePrices,
                       SalePrices = sp.SalePrices,
                       Quantity = sp.Quantity,
                       Availability = sp.Availability,
                       IsLive = sp.IsLive
                   };
        }
    
        public IEnumerable<SupplierProduct> GetProductsFromSupplier(string supplierId)
        {
            return SupplierProducts.Where(sp => sp.UserID == supplierId);
        }



        public IEnumerable<BasePrice> GetBasePricesForProduct(int productId)
        {
            return BasePrices.Where(bp => bp.SupplierProduct.Product.ProductID == productId);
        }

        public IEnumerable<SalePrice> GetSalePricesForProduct(int productId)
        {
            return SalePrices.Where(sp => sp.SupplierProduct.ProductID == productId);
        }

        public IEnumerable<ApplicationUser> GetSuppliersForProduct(int productId)
        {
            return SupplierProducts.Where(sp => sp.ProductID == productId).Select(sp => sp.Supplier);
        }

        
        public IEnumerable<SupplierProduct> GetSuppliedProducts(int productId)
        {
            return SupplierProducts.Where(sp => sp.ProductID == productId);
        }
    }
}
