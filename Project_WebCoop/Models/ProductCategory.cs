using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_WebCoop.Models
{
    public class ProductCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductCategoryID { get; set; }

        public int ProductID { get; set; }

        public int CategoryID { get; set; }

        [Required]
        public Product Product { get; set; }

        [Required]
        public Category Category { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ThroughDate { get; set; }
    }
}
