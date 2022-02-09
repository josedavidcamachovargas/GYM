using GYM.Data.GeneralSystem.IGeneralSystem;
using GYM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Data.GeneralSystem
{
    public class PaymentTypeSystem : SystemFunctions<PaymentType>, IPaymentTypeSystem    {
       
        private readonly ApplicationDbContext _db;

        public PaymentTypeSystem(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PaymentType paymentType)
        {
            var objFromDb = _db.PaymentTypes.FirstOrDefault(s => s.Id == paymentType.Id);

            if (objFromDb != null)
            {
                objFromDb.Id = paymentType.Id;
                objFromDb.PaymentDate = paymentType.PaymentDate;
                objFromDb.Description = paymentType.Description;
                objFromDb.Payment = paymentType.Payment;
                objFromDb.PeriodOfTime = paymentType.PeriodOfTime;
                objFromDb.PaymentMean = paymentType.PaymentMean;
                objFromDb.CustomerId = paymentType.CustomerId;
                objFromDb.ExpirationDate = paymentType.ExpirationDate;
                _db.SaveChanges();
            }
        }

        public async Task<object> InsertPaymentTypeAsync(PaymentType paymentType)
        {
            await _db.PaymentTypes.AddAsync(paymentType);
            return await _db.SaveChangesAsync();
        }

        public async Task<object> UpdatePaymentTypeAsync(PaymentType paymentType)
        {
            _db.PaymentTypes.Update(paymentType);
            return await _db.SaveChangesAsync();
        }

        public async Task<object> DeletePaymentTypeAsync(int id)
        {
            _db.PaymentTypes.Remove((PaymentType)ReadPaymentType(id));
            return await _db.SaveChangesAsync();
        }

        public object ReadPaymentType(int id)
        {
            PaymentType paymentType = _db.PaymentTypes.FirstOrDefault(u => u.Id.Equals(id));
            ApplicationUser Customer = _db.ApplicationUsers.FirstOrDefault(u => u.Id.Equals(paymentType.CustomerId));
            PaymentDescription Description = _db.PaymentDescriptions.FirstOrDefault(u => u.Id.Equals(paymentType.DescriptionId));
            paymentType.Customer = Customer;
            paymentType.Description = Description;
            return paymentType;
        }
    }
}

