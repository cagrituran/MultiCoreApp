using MultiCoreApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCoreApp.Core.IntRepository
{
    public interface IUserRepository:IRepository<User>
    {
        User UserFindById(int userId);
    }
}
