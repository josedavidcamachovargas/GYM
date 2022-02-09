using GYM.Data.GeneralSystem.IGeneralSystem;
using GYM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Data.GeneralSystem.IGeneralSystem
{
    public interface IPaymentDescriptionSystem : ISystemFunctions<PaymentDescription>
    {
        void Update(PaymentDescription paymentDescription);

        Task<object> InsertPaymentDescriptionAsync(PaymentDescription paymentDescription);

        Task<object> UpdatePaymentDescriptionAsync(PaymentDescription paymentDescription);

        Task<object> DeletePaymentDescriptionAsync(int id);

        object ReadPaymentDescription(int id);
    }
}
