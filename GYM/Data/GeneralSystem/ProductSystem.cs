using GYM.Data.GeneralSystem.IGeneralSystem;
using GYM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Data.GeneralSystem
{
    public class ProductSystem : SystemFunctions<Product>, IProductSystem
    {

        private readonly ApplicationDbContext _db;

        public ProductSystem(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product product)
        {
            var objFromDb = _db.Products.FirstOrDefault(s => s.Id == product.Id);

            if (objFromDb != null)
            {
                objFromDb.Id = product.Id;
                objFromDb.Name = product.Name;
                objFromDb.Description = product.Description;
                objFromDb.Price = product.Price;
                _db.SaveChanges();
            }
        }

        public async Task<object> InsertProductAsync(Product product)
        {
            await _db.Products.AddAsync(product);
            return await _db.SaveChangesAsync();
        }

        public async Task<object> UpdateProductAsync(Product product)
        {
            _db.Products.Update(product);
            return await _db.SaveChangesAsync();
        }

        public async Task<object> DeleteProductAsync(int id)
        {
            _db.Products.Remove((Product)ReadProduct(id));
            return await _db.SaveChangesAsync();
        }

        public object ReadProduct(int id)
        {
            return _db.Products.FirstOrDefault(u => u.Id.Equals(id));
        }
    }
}
