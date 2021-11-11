using Common.DTO;
using Common.Entities;
using System.Threading.Tasks;

namespace Client.Repository.Interface
{
    public interface IUserRepository
    {
        Task<User> LoginAsync(UserForLogin obj);
    }
}