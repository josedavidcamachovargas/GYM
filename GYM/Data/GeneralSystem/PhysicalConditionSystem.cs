using GYM.Data.GeneralSystem.IGeneralSystem;
using GYM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Data.GeneralSystem
{
    public class PhysicalConditionSystem : SystemFunctions<PhysicalCondition>, IPhysicalConditionSystem
    {
        private readonly ApplicationDbContext _db;

        public PhysicalConditionSystem(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PhysicalCondition physicalCondition)
        {
            var objFromDb = _db.PhysicalConditions.FirstOrDefault(s => s.Id == physicalCondition.Id);

            if (objFromDb != null)
            {
                objFromDb.Id = physicalCondition.Id;
                objFromDb.Weight = physicalCondition.Weight;
                objFromDb.Height = physicalCondition.Height;
                objFromDb.Diseases = physicalCondition.Diseases;
                objFromDb.Medicines = physicalCondition.Medicines;
                objFromDb.CustomerId = physicalCondition.CustomerId;
                _db.SaveChanges();
            }
        }

        public async Task<object> InsertPhysicalConditionAsync(PhysicalCondition physicalCondition)
        {
            await _db.PhysicalConditions.AddAsync(physicalCondition);
            return await _db.SaveChangesAsync();
        }

        public async Task<object> UpdatePhysicalConditionAsync(PhysicalCondition physicalCondition)
        {
            _db.PhysicalConditions.Update(physicalCondition);
            return await _db.SaveChangesAsync();
        }

        public async Task<object> DeletePhysicalConditionAsync(int id)
        {
            _db.PhysicalConditions.Remove((PhysicalCondition)ReadPhysicalCondition(id));
            return await _db.SaveChangesAsync();
        }

        public object ReadPhysicalCondition(int id)
        {
            PhysicalCondition physicalCondition = _db.PhysicalConditions.FirstOrDefault(u => u.Id.Equals(id));
            ApplicationUser Customer = _db.ApplicationUsers.FirstOrDefault(u => u.Id.Equals(physicalCondition.CustomerId));
            physicalCondition.Customer = Customer;
            return physicalCondition;
        }
    }
}
