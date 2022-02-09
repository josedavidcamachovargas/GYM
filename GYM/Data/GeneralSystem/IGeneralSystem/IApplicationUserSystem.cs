using GYM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GYM.Data.GeneralSystem.IGeneralSystem
    {
        public interface IApplicationUserSystem : ISystemFunctions<ApplicationUser>
        {
            void Update(ApplicationUser user);
            Task<object> InsertUserAsync(ApplicationUser user);

            Task<object> UpdateUserAsync(ApplicationUser user);

            Task<object> DeleteUserAsync(string id);

            object ReadUser(string id);
        }
    }
