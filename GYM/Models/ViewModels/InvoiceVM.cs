using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Models.ViewModels
{
    public class InvoiceVM
    {
        public Invoice Invoice { get; set; }

        public IEnumerable<SelectListItem> ProductBoughtsList { get; set; }

        public InvoiceDescription InvoiceDescription { get; set; }
    }
}
