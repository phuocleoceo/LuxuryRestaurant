using System.Threading.Tasks;
using Client.Repository.Interface;
using Common.BO;
using Common.DAO;

namespace Client.Repository.Implement
{
    public class UserRepository : IUserRepository
    {
        public Task<bool> LoginAsync(UserForLogin obj)
        {
            throw new System.NotImplementedException();
        }
    }
}