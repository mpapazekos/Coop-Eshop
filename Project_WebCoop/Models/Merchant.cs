using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_WebCoop.Models
{
    public class Merchant 
    {
  
        public int ID { get; set; }

        [Required]
        public string CompanyName { get; set; }
    }
}
