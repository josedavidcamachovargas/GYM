using GYM.Data.GeneralSystem.IGeneralSystem;
using GYM.Models;
using GYM.Utility;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Data.GeneralSystem
{
    public class SystemFacade : ISystemFacade
    {
        private readonly ApplicationDbContext _db;

        public IApplicationUserSystem ApplicationUser { get; private set; }

        public IPaymentTypeSystem PaymentType { get; private set; }

        public IPaymentDescriptionSystem PaymentDescription { get; private set; }

        public IPhysicalConditionSystem PhysicalCondition { get; private set; }

        public IProductSystem Product { get; private set; }

        public IInvoiceSystem Invoice { get; private set; }

        public IProductBoughtSystem ProductBought { get; private set; }

        public IAppointment Appointment { get; private set; }

        public ISP_Call Sp_Call { get; private set; }

        public SystemFacade(ApplicationDbContext db)
        {
            _db = db;
            ApplicationUser = new ApplicationUserSystem(_db);
            PaymentType = new PaymentTypeSystem(_db);
            PaymentDescription = new PaymentDescriptionSystem(_db);
            PhysicalCondition = new PhysicalConditionSystem(_db);
            Product = new ProductSystem(_db);
            Invoice = new InvoiceSystem(_db);
            ProductBought = new ProductBoughtSystem(_db);
            Appointment = new AppointmentSystem(_db);
            Sp_Call = new SP_Call(_db);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public async Task<object> Operation(string table, string id, string task, object item) {
            int generalId = -1;
            if (!table.Equals(TableNames.Users_Table)) { 
                generalId = Int32.Parse(id);
            }
            switch (task)
            {
                case "insert":
                    return await InsertData(table, item);
                case "update":
                    return await UpdateData(table, item);
                case "delete":
                    return await DeleteData(table, generalId, id);
                case "read":
                    return await ReadData(table, generalId, id);
            }
            return null;

        }

        public async Task<object> InsertData(string table, object item) {
            if (table.Equals("users"))
            {
                return await ApplicationUser.InsertUserAsync((ApplicationUser)item);
            }
            else if (table.Equals("invoices"))
            {
                return await Invoice.InsertInvoiceAsync((Invoice)item);
            }
            else if (table.Equals("paymentDescriptions"))
            {
                return await PaymentDescription.InsertPaymentDescriptionAsync((Models.PaymentDescription)item);
            }
            else if (table.Equals("paymentTypes"))
            {
                return await PaymentType.InsertPaymentTypeAsync((PaymentType)item);
            }
            else if (table.Equals("physicalConditions"))
            {
                return await PhysicalCondition.InsertPhysicalConditionAsync((PhysicalCondition)item);
            }
            else if (table.Equals("productBoughts"))
            {
                return await ProductBought.InsertProductBoughtAsync((ProductBought)item);
            }
            else if (table.Equals("products")) {
                return await Product.InsertProductAsync((Product)item);
            }
            return null;
        }

        public async Task<object> UpdateData(string table, object item)
        {
            if (table.Equals("users"))
            {
                return await ApplicationUser.UpdateUserAsync((ApplicationUser)item);
            }
            else if (table.Equals("invoices"))
            {
                return await Invoice.UpdateInvoiceAsync((Invoice)item);
            }
            else if (table.Equals("paymentDescriptions"))
            {
                return await PaymentDescription.UpdatePaymentDescriptionAsync((Models.PaymentDescription)item);
            }
            else if (table.Equals("paymentTypes"))
            {
                return await PaymentType.UpdatePaymentTypeAsync((PaymentType)item);
            }
            else if (table.Equals("physicalConditions"))
            {
                return await PhysicalCondition.UpdatePhysicalConditionAsync((PhysicalCondition)item);
            }
            else if (table.Equals("productBoughts"))
            {
                return await ProductBought.UpdateProductBoughtAsync((ProductBought)item);
            }
            else if (table.Equals("products"))
            {
                return await Product.UpdateProductAsync((Product)item);
            }
            return null;
        }

        public async Task<object> DeleteData(string table, int generalId, string userId)
        {
            if (table.Equals("users"))
            {
                return await ApplicationUser.DeleteUserAsync(userId);
            }
            else if (table.Equals("invoices"))
            {
                return await Invoice.DeleteInvoiceAsync(generalId);
            }
            else if (table.Equals("paymentDescriptions"))
            {
                return await PaymentDescription.DeletePaymentDescriptionAsync(generalId);
            }
            else if (table.Equals("paymentTypes"))
            {
                return await PaymentType.DeletePaymentTypeAsync(generalId);
            }
            else if (table.Equals("physicalConditions"))
            {
                return await PhysicalCondition.DeletePhysicalConditionAsync(generalId);
            }
            else if (table.Equals("productBoughts"))
            {
                return await ProductBought.DeleteProductBoughtAsync(generalId);
            }
            else if (table.Equals("products"))
            {
                return await Product.DeleteProductAsync(generalId);
            }
            return null;
        }

        public async Task<object> ReadData(string table, int generalId, string userId)
        {
            if (table.Equals("users"))
            {
                return ApplicationUser.ReadUser(userId);
            }
            else if (table.Equals("invoices"))
            {
                return Invoice.ReadInvoice(generalId);
            }
            else if (table.Equals("paymentDescriptions"))
            {
                return PaymentDescription.ReadPaymentDescription(generalId);
            }
            else if (table.Equals("paymentTypes"))
            {
                return PaymentType.ReadPaymentType(generalId);
            }
            else if (table.Equals("physicalConditions"))
            {
                return PhysicalCondition.ReadPhysicalCondition(generalId);
            }
            else if (table.Equals("productBoughts"))
            {
                return ProductBought.ReadProductBought(generalId);
            }
            else if (table.Equals("products"))
            {
                return Product.ReadProduct(generalId);
            }
            return null;
        }
    }
}
