using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Models
{
    public class PhysicalCondition
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public double Weight { get; set; }


        [Required]
        public double Height { get; set; }

        [Required]
        [MaxLength(300)]
        public string Diseases { get; set; }

        [Required]
        [MaxLength(300)]
        public string Medicines { get; set; }


        [Required]
        public string CustomerId { get; set; }


        [ForeignKey("CustomerId")]
        public ApplicationUser Customer { get; set; }
    }
}
