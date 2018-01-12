using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_WebCoop.Models
{
    public class ProductSale
    {
        public Individual Buyer { get; set; }

        public Product Product { get; set; }

        public DateTime SaleDate { get; set; }
    }
}
