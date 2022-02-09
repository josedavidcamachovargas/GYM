using GYM.Data.GeneralSystem.IGeneralSystem;
using GYM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Data.GeneralSystem
{
    public class ProductBoughtSystem : SystemFunctions<ProductBought>, IProductBoughtSystem
    {

        private readonly ApplicationDbContext _db;

        public ProductBoughtSystem(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ProductBought productBought)
        {
            var objFromDb = _db.ProductBoughts.FirstOrDefault(s => s.Id == productBought.Id);

            if (objFromDb != null)
            {
                objFromDb.Id = productBought.Id;
                objFromDb.InvoiceId = productBought.InvoiceId;
                objFromDb.ProductId = productBought.ProductId;
                objFromDb.Quantity = productBought.Quantity;
                _db.SaveChanges();
            }
        }

        public async Task<object> InsertProductBoughtAsync(ProductBought productBought)
        {
            await _db.ProductBoughts.AddAsync(productBought);
            return await _db.SaveChangesAsync();
        }

        public async Task<object> UpdateProductBoughtAsync(ProductBought productBought)
        {
            _db.ProductBoughts.Update(productBought);
            return await _db.SaveChangesAsync();
        }

        public async Task<object> DeleteProductBoughtAsync(int id)
        {
            _db.ProductBoughts.Remove((ProductBought)ReadProductBought(id));
            return await _db.SaveChangesAsync();
        }

        public object ReadProductBought(int id)
        {
            ProductBought productBought = _db.ProductBoughts.FirstOrDefault(u => u.Id.Equals(id));
            Invoice Invoice = _db.Invoices.FirstOrDefault(u => u.Id.Equals(productBought.InvoiceId));
            Product Product = _db.Products.FirstOrDefault(u => u.Id.Equals(productBought.ProductId));
            productBought.Invoice = Invoice;
            productBought.Product = Product;
            return productBought;
        }
    }
}
