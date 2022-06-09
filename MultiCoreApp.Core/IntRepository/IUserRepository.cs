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
        void AddUser(User user);
        User FindByEmailPassword(string email,string password);
        void SaveRefreshToken(int userId,string refreshToken);
        User GetUserWithRefreshToken(string refreshToken);

        void RemoveRefreshToken(User user);
    }
}
