using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_WebCoop.Models
{
    public class BasePrice
    {
        public int BasePriceID { get; set; }

        [Required]
        public SupplierProduct Product { get; set; }

        [Required]
        public decimal BaseUnitPrice { get; set; }

        [Required]
        public DateTime FromDate { get; set; }

        public DateTime ThroughDate { get; set; }
    }
}
