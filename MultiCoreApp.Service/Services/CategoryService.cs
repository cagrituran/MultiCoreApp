using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiCoreApp.Core.IntRepository;
using MultiCoreApp.Core.IntService;
using MultiCoreApp.Core.IntUnitOfWork;
using MultiCoreApp.Core.Models;

namespace MultiCoreApp.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unit, IRepository<Category> repo) : base(unit, repo)
        {
        }

        public async Task<Category> GetWithProductByIdAsync(Guid catId)
        {
            return await _unit.Category.GetWithProductByIdAsync(catId);
        }
    }
}
