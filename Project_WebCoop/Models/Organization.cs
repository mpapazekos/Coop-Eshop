using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_WebCoop.Models
{
    public class Organization 
    {
        public int OrganizationID { get; set; }

        [Required]
        public ApplicationUser User { get; set; }
        
        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string SSN { get; set; }
    }
}
