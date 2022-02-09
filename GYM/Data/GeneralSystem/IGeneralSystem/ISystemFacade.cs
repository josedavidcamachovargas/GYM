using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Data.GeneralSystem.IGeneralSystem
{
    public interface ISystemFacade : IDisposable
    {

        IApplicationUserSystem ApplicationUser { get; }

        IPaymentTypeSystem PaymentType { get; }

        IPaymentDescriptionSystem PaymentDescription { get; }

        IPhysicalConditionSystem PhysicalCondition { get; }

        IProductSystem Product { get; }

        IProductBoughtSystem ProductBought { get; }

        IInvoiceSystem Invoice { get; }

        ISP_Call Sp_Call { get; }

        public void Save();

        Task<object> Operation(string table, string id, string task, Object item);
    }
}

