using GYM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Data.Builder
{
    public class ProductsInvoiceDescription : Builder
    {
        public ProductsInvoice productsInvoice;

        public ProductsInvoiceDescription()
        {
            productsInvoice = new ProductsInvoice();
        }

        public void reset()
        {
            productsInvoice = new ProductsInvoice();
            
        }

        public void setCustomer(string id)
        {
            productsInvoice.CustomerId = id;
            productsInvoice.Description += "Identificador del cliente: " + id + "\n";
        }

        public void setProducts(List<ProductBought> productList, int paymentId)
        {
            productsInvoice.ProductList = productList;
            productsInvoice.Description += ".Lista de productos: " + ".\n";
            foreach (var product in productList) {
                productsInvoice.Description += "     Código: " + product.ProductId
                                             + "     Nombre: " + product.Product.Name 
                                             + "     Subtotal: " + (product.Product.Price * product.Quantity) + ".\n";
            }
        }

        public void setTotalPrice()
        {
            ApplicationDbContext _context = ApplicationDbContext.getInstance();

            double total = 0;

            foreach(var product in productsInvoice.ProductList) {
                total += _context.Products.FirstOrDefault(p => p.Id == product.ProductId).Price * product.Quantity;
            }

            productsInvoice.Description += "Total a pagar: " + total + ".\n";
        }
    }
}
