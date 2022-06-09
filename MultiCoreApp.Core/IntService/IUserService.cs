using MultiCoreApp.Core.Models;
using MultiCoreApp.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCoreApp.Core.IntService
{
    public interface IUserService:IService<User>
    {
        BaseResponse<User> UserFindById(int userId);
        BaseResponse<User> AddUser(User user);
        BaseResponse<User> FindByEmailPassword(string email, string password);
        void SaveRefreshToken(int userId, string refreshToken);
        BaseResponse<User> GetUserWithRefreshToken(string refreshToken);

        void RemoveRefreshToken(User user);
    }
}
