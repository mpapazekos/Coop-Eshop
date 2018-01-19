using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_WebCoop.Models
{
    public class SupplierProduct
    {
        public string UserID { get; set; }

        public int ProductID { get; set; }

        [Required]
        [ForeignKey("UserID")]
        public ApplicationUser Supplier { get; set; }

        [Required]
        [ForeignKey("ProductID")]
        public Product Product { get; set; }

        [Required]
        public decimal BasePrice { get; set; }

        public decimal SalePrice { get; set; }

        public string Availability { get; set; }
    
        public bool IsLive { get; set; }
    }
}
