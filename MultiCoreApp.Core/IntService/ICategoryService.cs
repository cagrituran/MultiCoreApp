using MultiCoreApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCoreApp.Core.IntService
{
    public interface ICategoryService:IService<Category>
    {
        Task<Category> GetWithProductByIdAsync(Guid catId);
    }
}
