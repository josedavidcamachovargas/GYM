using GYM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Data.Builder
{
    public class ProductsInvoice
    {
        public List<ProductBought> ProductList { get; set; }

        public string CustomerId { get; set; }

        public double TotalPrice { get; set; }

        public string Description { get; set; }
    }
}
