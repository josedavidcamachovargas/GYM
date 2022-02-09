using GYM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Data.Builder
{
    public class Director
    {
        private Builder builder;

        public Director()
        {
        }

        public void setBuilder(Builder builder) {
            this.builder = builder;
        }

        public void contructPaymentInvoice(Builder builder, PaymentType paymentType) {
            builder.setCustomer(paymentType.CustomerId);
            builder.setProducts(null, paymentType.Id);
            builder.setTotalPrice();
        }

        public void contructProductsInvoice(Builder builder, List<ProductBought> productList)
        {
            string customerId = productList.First().Invoice.CustomerId;
            builder.setCustomer(customerId);
            builder.setProducts(productList, -1);
            builder.setTotalPrice();
        }

    }
}
