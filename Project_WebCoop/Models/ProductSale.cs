using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_WebCoop.Models
{
    public class ProductSale
    {
        public int ClientID { get; set; }

        public int OrderID { get; set; }

        public DateTime SaleDate { get; set; }
    }
}
