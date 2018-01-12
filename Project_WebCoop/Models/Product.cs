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

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive value.")]
        public decimal MerchantPrice { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive value.")]
        public decimal Price { get; set; }
     
        [Required]
        public Merchant Merchant  { get; set; }

        public bool IsLive { get; set; }

        public Availability Availability { get; set; }

        public int QuantityInStock { get; set; }

        public string ImagePath { get; set; }


    }
}
