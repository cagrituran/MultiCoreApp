using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultiCoreApp.Core.IntService
{
    public interface IService<T> where T: class
    {
        //Update-Delete Asenkron islemi yoktur
        //select kısmı
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate); // select * from Product where Name = "Apple"

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);  // yukardakiyle aynı
        Task<IQueryable<T>> QListAsync();
        // Add kısmı
        Task<T> AddAsync(T entity);// Tekli kayıt ekleme
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);// Grup olarak kayıt ekleme
        T Update(T entity);

        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(IEnumerable<T> entities);
    }
}
