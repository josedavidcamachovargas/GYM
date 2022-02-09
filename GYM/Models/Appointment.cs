using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; } = DateTime.Now.Date;

        [Required]
        public int AppointmentHour { get; set; } = DateTime.Now.Date.Hour;


        [Required]
        public string CustomerId { get; set; }


        [ForeignKey("CustomerId")]
        public ApplicationUser Customer { get; set; }
    }
}
