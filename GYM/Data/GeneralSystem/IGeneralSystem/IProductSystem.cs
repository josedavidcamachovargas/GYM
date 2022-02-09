using GYM.Data.GeneralSystem.IGeneralSystem;
using GYM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Data.GeneralSystem.IGeneralSystem
{
    public interface IProductSystem : ISystemFunctions<Product>
    {
        void Update(Product product);

        Task<object> InsertProductAsync(Product product);

        Task<object> UpdateProductAsync(Product product);

        Task<object> DeleteProductAsync(int id);

        object ReadProduct(int id);
    }
}
