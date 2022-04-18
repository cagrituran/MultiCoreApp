using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiCoreApp.Core.IntRepository;
using MultiCoreApp.Core.IntUnitOfWork;
using MultiCoreApp.DataAccessLayer.Repository;

namespace MultiCoreApp.DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MultiDbContext _db;
        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;
        private CustomerRepository _customerRepository;

        public UnitOfWork(MultiDbContext db)
        {
            _db = db;
               
        }
        public IProductRepository Product => _productRepository ??= new ProductRepository(_db);

        public ICategoryRepository Category => _categoryRepository ??= new CategoryRepository(_db);

        public ICustomerRepository Customer => _customerRepository ??= new CustomerRepository(_db);

        public void Commit()
        {
            _db.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
