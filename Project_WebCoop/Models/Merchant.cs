using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_WebCoop.Models
{
    public class Merchant 
    {
        [BindNever]
        public int MerchantID { get; set; }

        [BindNever]
        public ApplicationUser User { get; set; }
        
        public string CompanyName { get; set; }

        public string SSN { get; set; }
    }
}
