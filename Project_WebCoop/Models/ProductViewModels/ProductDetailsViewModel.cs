using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_WebCoop.Models.ProductViewModels
{
    public class ProductDetailsViewModel
    {
        public Product MainProduct { get; set; }

        public IEnumerable<SupplierProduct> SupplierProducts { get; set;}

    }
}
