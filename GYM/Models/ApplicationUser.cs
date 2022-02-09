using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string IDCard { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [NotMapped]
        public string Role { get; set; }
    }
}
