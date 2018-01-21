using Project_WebCoop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_WebCoop.Services
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<SupplierProduct> SupplierProducts { get; } 
        
        IEnumerable<BasePrice> BasePrices { get;}
        IEnumerable<SalePrice> SalePrices { get;}

        IEnumerable<Category> Categories { get; }
        IEnumerable<ProductCategory> ProductCategories { get; }


        void StoreNewProduct(Product product);

        void StoreNewSalePrice(SalePrice salePrice);

        void StoreNewSupplierProduct(SupplierProduct supplierProduct);

        void StoreNewBasePrice(BasePrice basePrice);

        void StoreNewCategory(Category category);


        Product GetProductById(int productId);
        Category GetCategoryByName(string categoryName);

        IEnumerable<string> GetCategoryNames();

        IEnumerable<ApplicationUser> GetCurrentSuppliers();

        IEnumerable<SupplierProduct> GetLiveProducts();

        IEnumerable<SupplierProduct> FindByName(string productName);

        IEnumerable<SupplierProduct> GetProductsInCategory(string categoryName);

        IEnumerable<SupplierProduct> GetProductsFromSupplier(string supplierId);

        IEnumerable<SupplierProduct> GetSuppliedProducts(int productId);

        IEnumerable<BasePrice> GetBasePricesForProduct(int productId);

        IEnumerable<SalePrice> GetSalePricesForProduct(int productId);

        IEnumerable<ApplicationUser> GetSuppliersForProduct(int productId);
    }
}
