using GYM.Data.GeneralSystem.IGeneralSystem;
using GYM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Data.GeneralSystem.IGeneralSystem
{
    public interface IPaymentTypeSystem : ISystemFunctions<PaymentType>
    {
        void Update(PaymentType paymentType);

        Task<object> InsertPaymentTypeAsync(PaymentType paymentType);

        Task<object> UpdatePaymentTypeAsync(PaymentType paymentType);

        Task<object> DeletePaymentTypeAsync(int id);

        object ReadPaymentType(int id);
    }
   
}
