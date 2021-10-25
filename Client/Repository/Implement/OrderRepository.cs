using Client.Repository.Interface;
using Common.BO;
using Common.Extension;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Client.Repository.Implement
{
    public class OrderRepository : IOrderRepository
    {
        private TcpClient client;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;

        private async Task InitStream()
        {
            client = new TcpClient();
            await client.ConnectAsync(IPAddress.Parse("127.0.0.1"), 1008);
            stream = client.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream) { AutoFlush = true };
        }

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
