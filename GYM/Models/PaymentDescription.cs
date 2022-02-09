using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Models
{
    public class PaymentDescription
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Description")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
