using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_WebCoop.Models
{
    public class SalePrice
    {
        public int SalePriceID { get; set; }

        [Required]
        public  SupplierProduct SupplierProduct { get; set; }

        [Required]
        public decimal SaleUnitPrice { get; set; }

        [Required]
        public DateTime FromDate { get; set; }

        public DateTime ThroughDate { get; set; }

    }
}
