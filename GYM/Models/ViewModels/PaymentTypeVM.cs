using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Models.ViewModels
{
    public class PaymentTypeVM
    {
        public PaymentType PaymentType { get; set; }

        public IEnumerable<SelectListItem> PaymentDescriptionList { get; set; }
    }
}
