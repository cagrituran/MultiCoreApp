using MultiCoreApp.Core.IntRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCoreApp.Core.IntUnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; } // add ve savechange arasında eğer olusmussa bunu gerçeklestirebiliriz araya sokma işlemi
        ICategoryRepository Category { get; }

        ICustomerRepository Customer { get; }
        void Commit(); // Update ve Remove için
        Task CommitAsync();//bu savechange islemi olacak
    }
}
