using GYM.Data.GeneralSystem.IGeneralSystem;
using GYM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Data.GeneralSystem
{
    public class PaymentDescriptionSystem : SystemFunctions<PaymentDescription>, IPaymentDescriptionSystem
    {
        private readonly ApplicationDbContext _db;

        public PaymentDescriptionSystem(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PaymentDescription paymentDescription)
        {
            var objFromDb = _db.PaymentDescriptions.FirstOrDefault(s => s.Id == paymentDescription.Id);

            if (objFromDb != null)
            {
                objFromDb.Id = paymentDescription.Id;
                objFromDb.Name = paymentDescription.Name;
                _db.SaveChanges();
            }
        }

        public async Task<object> InsertPaymentDescriptionAsync(PaymentDescription paymentDescription)
        {
            await _db.PaymentDescriptions.AddAsync(paymentDescription);
            return _db.SaveChangesAsync();
        }

        public async Task<object> UpdatePaymentDescriptionAsync(PaymentDescription paymentDescription)
        {
            _db.PaymentDescriptions.Update(paymentDescription);
            return await _db.SaveChangesAsync();
        }

        public async Task<object> DeletePaymentDescriptionAsync(int id)
        {
            _db.PaymentDescriptions.Remove((PaymentDescription)ReadPaymentDescription(id));
            return await _db.SaveChangesAsync();
        }

        public Object ReadPaymentDescription(int id)
        {
            return _db.PaymentDescriptions.FirstOrDefault(u => u.Id.Equals(id));
        }
    }
}
