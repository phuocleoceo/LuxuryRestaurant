using Client.Repository.Interface;
using Common.DTO;
using Common.Extension;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Client.Repository.Implement
{
    public class RequestRepository : Repository, IRequestRepository
    {
        public RequestRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<bool> SendRequest(UserRequest ur)
        {
            string user = JsonConvert.SerializeObject(ur);
            string response = await SendAndReceiveAsync(Constant.Message_Request, user);
            return response != null ? true : false;
        }
    }
}
