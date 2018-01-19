using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public string ImagePath { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }

        public ICollection<SupplierProduct> SupplierProducts { get; set; }

        public Product() { }

        public Product(string name, string description)
        {
            Name = name;
            Description = description;
        }

    }
}
