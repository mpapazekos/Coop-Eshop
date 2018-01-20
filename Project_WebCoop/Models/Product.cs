using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_WebCoop.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Please enter the name of the product.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a product description.")]
        public string Description { get; set; }


        [Required]
        public DateTime DateAdded;

        public DateTime DateRemoved;

        public string ImagePath { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();

        public ICollection<SupplierProduct> SupplierProducts { get; set; } = new List<SupplierProduct>();

        public Product() { }

        public Product(string name, string description)
        {
            Name = name;
            Description = description;
        }

        //[NotMapped]
        //public IEnumerable<Category> Categories => GetCategories();

        
        //private IEnumerable<Category> GetCategories()
        //{

        //    List<Category > categories = new List<Category>();

        //    foreach (var item in ProductCategories.Where(pc => pc.Product.Equals(this)))
        //    {
        //        Categories.Append(item.Category);
        //    }

        //    return categories;
        //}
    }
}
