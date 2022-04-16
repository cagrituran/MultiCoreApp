using MultiCoreApp.Core.IntRepository;
using MultiCoreApp.Core.IntService;
using MultiCoreApp.Core.IntUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultiCoreApp.Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        public readonly IUnitOfWork _unit;
        private readonly IRepository<T> _repo;

        public Service(IUnitOfWork unit, IRepository<T> repo)
        {
            _unit = unit;
            _repo = repo;   
        }
        public async Task<T> AddAsync(T entity)
        {
            await _repo.AddAsync(entity);
            await _unit.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _repo.AddRangeAsync(entities);
            await _unit.CommitAsync();
            return entities;
        }

        public async Task DeleteAsync(T entity)
        {
            _repo.Remove(entity);
            await _unit.CommitAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            _repo.RemoveRange(entities);
            await _unit.CommitAsync();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repo.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<IQueryable<T>> QListAsync()
        {
            return await _repo.QListAsync();
        }

        public void Remove(T entity)
        {
            _repo.Remove(entity);
            _unit.Commit();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _repo.RemoveRange(entities);
            _unit.Commit();
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repo.SingleOrDefaultAsync(predicate);
        }

        public T Update(T entity)
        {
            _repo.Update(entity);
            _unit.Commit();
            return entity;
        }

        public async Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate)
        {
            return await _repo.Where(predicate);
        }
    }
}
