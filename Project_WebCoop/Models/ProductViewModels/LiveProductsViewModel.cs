using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_WebCoop.Models.ProductViewModels
{
    public class LiveProductsViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public decimal MinPrice { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}
