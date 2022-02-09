using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Models
{
    public class InvoiceDescription
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(300)]
        public string TotalDescription { get; set; }

        [Required]
        public int InvoiceId { get; set; }

        [ForeignKey("InvoiceId")]
        public Invoice Invoice { get; set; }
    }
}
