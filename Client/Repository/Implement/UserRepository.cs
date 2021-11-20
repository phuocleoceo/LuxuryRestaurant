using Microsoft.Extensions.Configuration;
using Client.Repository.Interface;
using System.Threading.Tasks;
using Common.Extension;
using Newtonsoft.Json;
using Common.Entities;
using Common.DTO;

namespace Client.Repository.Implement
{
    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<User> LoginAsync(UserForLogin obj)
        {
            string user = JsonConvert.SerializeObject(obj);
            string response = await SendAndReceiveAsync(Constant.Login, user);
            return response != null ? JsonConvert.DeserializeObject<User>(response) : null;
        }
    }
}