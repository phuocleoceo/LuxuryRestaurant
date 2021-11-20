using Microsoft.Extensions.Configuration;
using Client.Repository.Interface;
using System.Threading.Tasks;
using Common.Extension;
using System;

namespace Client.Repository.Implement
{
    public class OrderRepository : Repository, IOrderRepository
    {
        public OrderRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<bool> PlaceOrder(int UserId)
        {
            string response = await SendAndReceiveAsync(Constant.Place_Order, UserId.ToString());
            return response != null ? Convert.ToBoolean(response) : false;
        }
    }
}
