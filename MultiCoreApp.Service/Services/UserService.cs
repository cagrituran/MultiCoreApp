using MultiCoreApp.Core.IntRepository;
using MultiCoreApp.Core.IntService;
using MultiCoreApp.Core.IntUnitOfWork;
using MultiCoreApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCoreApp.Service.Services
{
    public class UserService : Service<User>,IUserService
    {
        public UserService(IUnitOfWork unit,IRepository<User> repo):base(unit,repo)
        {

        }

        public User UserFindById(int userId)
        {
            return _unit.User.UserFindById(userId);
        }
    }
}
