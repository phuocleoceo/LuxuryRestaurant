using Common.DTO;
using Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Repository.Interface
{
    public interface IUserRepository
    {
        Task<User> LoginAsync(UserForLogin obj);

        Task<User> FindUserById(int UserId);

        Task<List<User>> LoadUserWithOrder();

        Task<bool> SaveAsync();
    }
}