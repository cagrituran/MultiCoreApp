using MultiCoreApp.Core.IntRepository;
using MultiCoreApp.Core.IntService;
using MultiCoreApp.Core.IntUnitOfWork;
using MultiCoreApp.Core.Models;
using MultiCoreApp.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCoreApp.Service.Services
{
    public class UserService : Service<User>,IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUnitOfWork unit, IRepository<User> repo) : base(unit, repo)
        {
        }

        public BaseResponse<User> UserFindById(int userId)
        {
            try
            {
                User user = _unit.User.UserFindById(userId);
                if (user==null)
                {
                    return new BaseResponse<User>("Kullanici bulunamadi.");
                }
                return new BaseResponse<User>(user);
            }
            catch (Exception ex)
            {
                return new BaseResponse<User>($"Kullanici aranirken bir hata meydana geldi : {ex.Message}");
            }
        }

        public BaseResponse<User> AddUser(User user)
        {
            try
            {
                _unit.User.AddUser(user);
                _unit.Commit();
                return new BaseResponse<User>(user);
            }
            catch (Exception ex)
            {
                return new BaseResponse<User>($"Kullanici eklenirken bir hata meydana geldi. :{ex.Message}");
            }
        }

        public BaseResponse<User> FindByEmailPassword(string email, string password)
        {
            try
            {
                User user = _unit.User.FindByEmailPassword(email, password);
                if (user == null)
                {
                    return new BaseResponse<User>("Kullanici bulunamadi.");
                }
                return new BaseResponse<User>(user);
            }
            catch (Exception ex)
            {
                return new BaseResponse<User>($"Kullanici aranirken bir hata meydana geldi : {ex.Message}");
            }
        }

        public void SaveRefreshToken(int userId, string refreshToken)
        {
            try
            {
                _unit.User.SaveRefreshToken(userId, refreshToken);
                _unit.Commit();
            }
            catch (Exception)
            {

            }
        }

        public BaseResponse<User> GetUserWithRefreshToken(string refreshToken)
        {
            try
            {
                User user = _unit.User.GetUserWithRefreshToken(refreshToken);
                if (user == null)
                {
                    return new BaseResponse<User>("Kullanici bulunamadi.");
                }
                return new BaseResponse<User>(user);
            }
            catch (Exception ex)
            {
                return new BaseResponse<User>($"Kullanici aranirken bir hata meydana geldi : {ex.Message}");
            }
        }

        public void RemoveRefreshToken(User user)
        {
            try
            {
                _unit.User.RemoveRefreshToken(user);
                _unit.Commit();
            }
            catch (Exception)
            {

            }
        }

    }
}
