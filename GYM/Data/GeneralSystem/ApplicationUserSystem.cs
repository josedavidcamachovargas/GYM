using GYM.Data.GeneralSystem.IGeneralSystem;
using GYM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Data.GeneralSystem
{
    public class ApplicationUserSystem : SystemFunctions<ApplicationUser>, IApplicationUserSystem
    {
        private readonly ApplicationDbContext _db;

        public ApplicationUserSystem(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ApplicationUser applicationUser)
        {
            var objFromDb = _db.ApplicationUsers.FirstOrDefault(s => s.Id == applicationUser.Id);

            if (objFromDb != null)
            {
                objFromDb.Name = applicationUser.Name;
                objFromDb.LastName = applicationUser.LastName;
                objFromDb.IDCard = applicationUser.IDCard;
                objFromDb.BirthDate = applicationUser.BirthDate;
                objFromDb.Phone = applicationUser.Phone;
                objFromDb.RegistrationDate = applicationUser.RegistrationDate;
                objFromDb.Role = applicationUser.Role;
                _db.SaveChanges();
            }
        }

        public async Task<object> InsertUserAsync(ApplicationUser user)
        {
            await _db.ApplicationUsers.AddAsync(user);
            return await _db.SaveChangesAsync();
        }

        public async Task<object> UpdateUserAsync(ApplicationUser user)
        {
            _db.ApplicationUsers.Update(user);
            return await _db.SaveChangesAsync();
        }

        public async Task<object> DeleteUserAsync(string userId)
        {
            _db.ApplicationUsers.Remove((ApplicationUser)ReadUser(userId));
            return await _db.SaveChangesAsync();
        }

        public object ReadUser(string userId)
        {
            return _db.ApplicationUsers.FirstOrDefault(u => u.Id.Equals(userId));
        }


    }
}
