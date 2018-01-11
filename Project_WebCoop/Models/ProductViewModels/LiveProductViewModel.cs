using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_WebCoop.Models.ProductViewModels
{
    public class LiveProductViewModel
    {
        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public string Availability { get; set; }

        public string Category { get; set; }

        public string Manufacturer { get; set; }

        public string ImagePath { get; set; }
    }
}
