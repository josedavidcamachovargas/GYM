using GYM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Data.Builder
{
    public interface Builder
    {
        void reset();
        void setProducts(List<ProductBought> productList, int paymentId);
        void setCustomer(string id);
        void setTotalPrice();
    }
}
