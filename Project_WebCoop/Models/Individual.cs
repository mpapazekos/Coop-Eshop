using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_WebCoop.Models
{
    public class Individual
    {
        public int IndividualID { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }


        [NotMapped]
        public string FullName => FirstName + " " + LastName;
    }
}
