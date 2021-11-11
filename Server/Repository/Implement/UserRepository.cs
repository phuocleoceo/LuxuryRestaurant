using Common.DTO;
using Common.Entities;
using Common.Extension;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Repository.Implement
{
    public class UserRepository : IUserRepository
    {
        private readonly LuxuryContext _db;
        public UserRepository()
        {
            _db = new LuxuryContext();
        }

        public async Task<User> LoginAsync(UserForLogin obj)
        {
            string un = obj.UserName;
            string pw = obj.Password.GetMD5();
            User user = await _db.Users
                        .SingleOrDefaultAsync(c => c.UserName == un && c.Password == pw);
            if (user == null)
            {
                return null;
            }
            user.Password = "";
            return user;
        }

        public async Task<User> FindUserById(int UserId)
        {
            return await _db.Users.FindAsync(UserId);
        }

        public async Task<List<User>> LoadUserWithOrder()
        {
            return await _db.Users
                .Where(c => c.Role == Constant.Role_Customer).ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _db.SaveChangesAsync() >= 0;
        }
    }
}