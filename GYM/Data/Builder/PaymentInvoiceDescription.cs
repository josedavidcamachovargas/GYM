using GYM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Data.Builder
{
    public class PaymentInvoiceDescription : Builder
    {
        public PaymentInvoice paymentInvoice;

        public PaymentInvoiceDescription()
        {
            paymentInvoice = new PaymentInvoice();
        }
        public void reset()
        {
            paymentInvoice = new PaymentInvoice();
        }

        public void setCustomer(string id)
        {
            paymentInvoice.CustomerId = id;
            paymentInvoice.Description += "Identificador del cliente: " + id + "\n";
        }

        public void setProducts(List<ProductBought> productList, int paymentId)
        {
            paymentInvoice.PaymentId = paymentId;
            paymentInvoice.Description += "Identificador de la membresía: " + paymentId + "\n";
        }

        public void setTotalPrice()
        {
            ApplicationDbContext _context = ApplicationDbContext.getInstance();
            paymentInvoice.TotalPrice = _context.PaymentTypes.FirstOrDefault(pt => pt.Id == paymentInvoice.PaymentId).Payment;
            paymentInvoice.Description += "Precio total de membresía: " + paymentInvoice.TotalPrice + " colones" + "\n";
        }
    }
}
