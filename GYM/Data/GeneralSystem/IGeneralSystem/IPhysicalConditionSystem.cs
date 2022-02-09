using GYM.Data.GeneralSystem.IGeneralSystem;
using GYM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Data.GeneralSystem.IGeneralSystem
{
    public interface IPhysicalConditionSystem : ISystemFunctions<PhysicalCondition>
    {
        void Update(PhysicalCondition physicalCondition);
        Task<object> InsertPhysicalConditionAsync(PhysicalCondition physicalCondition);

        Task<object> UpdatePhysicalConditionAsync(PhysicalCondition physicalCondition);

        Task<object> DeletePhysicalConditionAsync(int id);

        object ReadPhysicalCondition(int id);

    }
}
