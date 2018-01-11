using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_WebCoop.Models.ProductViewModels
{
    public class StagedProductViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal InitialPrice { get; set; }

        [Required]
        public DateTime DateProduced { get; set; }

    }
}
