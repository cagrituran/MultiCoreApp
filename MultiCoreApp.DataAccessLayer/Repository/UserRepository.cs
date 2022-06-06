using MultiCoreApp.Core.IntRepository;
using MultiCoreApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCoreApp.DataAccessLayer.Repository
{
    public class UserRepository:Repository<User>,IUserRepository
    {
        public UserRepository(MultiDbContext context):base(context)
        {

        }
    }
}
