using GYM.Data.GeneralSystem.IGeneralSystem;
using GYM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Data.GeneralSystem.IGeneralSystem
{
    public interface IProductBoughtSystem : ISystemFunctions<ProductBought>
    {
        void Update(ProductBought productBought);

        Task<object> InsertProductBoughtAsync(ProductBought productBought);

        Task<object> UpdateProductBoughtAsync(ProductBought productBought);

        Task<object> DeleteProductBoughtAsync(int id);

        object ReadProductBought(int id);
    }
}
