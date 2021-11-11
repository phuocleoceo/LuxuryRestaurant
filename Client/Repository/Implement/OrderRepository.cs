using Client.Repository.Interface;
using Common.DTO;
using Common.Extension;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Client.Repository.Implement
{
    public class OrderRepository : Repository, IOrderRepository
    {
        public OrderRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<bool> PlaceOrder(int UserId)
        {
            try
            {
                await InitStream();
                RequestModel rm = new RequestModel
                {
                    Header = Constant.Place_Order,
                    Payload = UserId.ToString()
                };
                string rmJson = JsonConvert.SerializeObject(rm);
                await writer.WriteLineAsync(rmJson);

                string response = await reader.ReadLineAsync();
                return Convert.ToBoolean(response);
            }
            catch
            {
                return false;
            }
            finally
            {
                stream.Close();
                client.Close();
            }
        }
    }
}
