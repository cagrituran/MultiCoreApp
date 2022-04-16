using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MultiCoreApp.Core.IntRepository;
using MultiCoreApp.Core.Models;

namespace MultiCoreApp.DataAccessLayer.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private MultiDbContext multiDbContext { get => _db as MultiDbContext; }
        public ProductRepository(MultiDbContext db) : base(db)
        {
        }

        public async Task<Product> GetWithCategoryByIdAsync(Guid proId)
        {
            var product = _db.Products.Include(s => s.Category).FirstOrDefaultAsync(s => s.Id == proId);
            return (await product)!;
        }
    }
}
