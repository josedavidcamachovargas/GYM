using GYM.Data.GeneralSystem.IGeneralSystem;
using GYM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Data.GeneralSystem
{
    public class InvoiceSystem : SystemFunctions<Invoice>, IInvoiceSystem
    {

        private readonly ApplicationDbContext _db;

        public InvoiceSystem(ApplicationDbContext db) : base(db)
        {
            _db = db;
            //_db = ApplicationDbContext.getInstance();
        }

        public void Update(Invoice invoice)
        {
            var objFromDb = _db.Invoices.FirstOrDefault(s => s.Id == invoice.Id);

            if (objFromDb != null)
            {
                objFromDb.Id = invoice.Id;
                objFromDb.PaymentDate = invoice.PaymentDate;
                objFromDb.CustomerId = invoice.CustomerId;
                _db.SaveChanges();
            }
        }

        public async Task<object> InsertInvoiceAsync(Invoice invoice)
        {

            await _db.AddAsync(invoice);
            return await _db.SaveChangesAsync();
        }

        public async Task<object> UpdateInvoiceAsync(Invoice invoice)
        {
            _db.Invoices.Update(invoice);
            return await _db.SaveChangesAsync();
        }
    

        public async Task<object> DeleteInvoiceAsync(int id)
        {
            _db.Invoices.Remove((Invoice)ReadInvoice(id));
            return await _db.SaveChangesAsync();
        }

        public object ReadInvoice(int id)
        {
            Invoice invoice = _db.Invoices.FirstOrDefault(u => u.Id.Equals(id));
            ApplicationUser Customer = _db.ApplicationUsers.FirstOrDefault(u => u.Id.Equals(invoice.CustomerId));
            invoice.Customer = Customer;
            return invoice;
        }

    }
}
