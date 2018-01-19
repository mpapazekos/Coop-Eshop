using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_WebCoop.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
