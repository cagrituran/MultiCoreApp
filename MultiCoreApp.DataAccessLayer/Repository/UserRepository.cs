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

        public void AddUser(User user)
        {
            multiDbContext.Users.Add(user);
        }

        public User FindByEmailPassword(string email, string password)
        {
           return multiDbContext.Users.Where(x=>x.Email == email && x.Password== password).FirstOrDefault()!;
        }

        public void SaveRefreshToken(int userId, string refreshToken)
        {
            User newUser = UserFindById(userId);
            newUser.RefreshToken=refreshToken;
            newUser.RefreshTokenEndDate=DateTime.Now.AddMinutes(60);
        }

        public User GetUserWithRefreshToken(string refreshToken)
        {
           return multiDbContext.Users.FirstOrDefault(s=>s.RefreshToken==refreshToken)!;
        }

        public void RemoveRefreshToken(User user)
        {
            User newUser = UserFindById(user.Id);
            newUser.RefreshToken=null;
            newUser.RefreshTokenEndDate=null;
        }
    }
}
