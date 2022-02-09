using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Models
{
    public class PaymentType
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; } = DateTime.Now.Date;

        [Required]
        public int DescriptionId { get; set; }

        [ForeignKey("DescriptionId")]
        public PaymentDescription Description { get; set; }

        [Required]
        public double Payment { get; set; }

        [Required]
        public int PeriodOfTime { get; set; }

        [Required]
        public string PaymentMean { get; set; }
        
        [Required]
        public string CustomerId { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; } = DateTime.Now.Date;

        [ForeignKey("CustomerId")]
        public ApplicationUser Customer { get; set; }


    }
}
