using MultiCoreApp.Core.IntRepository;
using MultiCoreApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCoreApp.DataAccessLayer.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private MultiDbContext multiDbContext { get => _db as MultiDbContext; }
        public UserRepository(MultiDbContext context):base(context)
        {

        }

        public User UserFindById(int userId)
        {
            
            return multiDbContext.Users.Find(userId)!;
        }
    }
}
