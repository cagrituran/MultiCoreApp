using MultiCoreApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiCoreApp.Core.IntService;
using MultiCoreApp.Core.IntUnitOfWork;
using MultiCoreApp.Core.IntRepository;

namespace MultiCoreApp.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unit, IRepository<Product> repo) : base(unit, repo)
        {
        }

        public async Task<Product> GetWithCategoryByIdAsync(Guid proId)
        {
            return await _unit.Product.GetWithCategoryByIdAsync(proId);
        }
    }
}
