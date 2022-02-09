using GYM.Data.GeneralSystem.IGeneralSystem;
using GYM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Data.GeneralSystem.IGeneralSystem
{
    public interface IInvoiceSystem : ISystemFunctions<Invoice>
    {
        void Update(Invoice invoice);
        Task<object> InsertInvoiceAsync(Invoice invoice);

        Task<object> UpdateInvoiceAsync(Invoice invoice);

        Task<object> DeleteInvoiceAsync(int id);

        object ReadInvoice(int id);
    }
}
