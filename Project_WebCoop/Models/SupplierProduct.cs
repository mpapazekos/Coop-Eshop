﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_WebCoop.Models
{
    public class SupplierProduct
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplierProductID { get; set; }

        public string UserID { get; set; }

        public int ProductID { get; set; }

        [Required]
        [ForeignKey("UserID")]
        public ApplicationUser Supplier { get; set; }

        [Required]
        [ForeignKey("ProductID")]
        public Product Product { get; set; }

        public ICollection<BasePrice> BasePrices { get; set; }

        public ICollection<SalePrice> SalePrices { get; set; }

        public string Availability { get; set; }
    
        public bool IsLive { get; set; }
    }
}