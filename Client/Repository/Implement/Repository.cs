using Microsoft.Extensions.Configuration;
using Client.Repository.Interface;
using System.Threading.Tasks;
using System.Net.Sockets;
using Newtonsoft.Json;
using Common.DTO;
using System.Net;
using System.IO;
using System;

namespace Client.Repository.Implement
{
    public class Repository : IRepository
    {
        private TcpClient client;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;

        private readonly IConfiguration _configuration;
        private IPAddress ip;
        private int port;

        public Repository(IConfiguration configuration)
        {
            _configuration = configuration;
            ip = IPAddress.Parse(_configuration.GetSection("ServerInfor:IP").Value);
            port = Convert.ToInt32(_configuration.GetSection("ServerInfor:Port").Value);
        }

        private async Task InitStream()
        {
            client = new TcpClient();
            await client.ConnectAsync(ip, port);
            stream = client.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream) { AutoFlush = true };
        }

        public async Task<string> SendAndReceiveAsync(string Header, string Body)
        {
            try
            {
                await InitStream();
                RequestModel rm = new RequestModel
                {
                    Header = Header,
                    Body = Body
                };
                string request = JsonConvert.SerializeObject(rm);
                await writer.WriteLineAsync(request);

                string response = await reader.ReadLineAsync();
                return response;
            }
            catch
            {
                return null;
            }
            finally
            {
                stream.Close();
                client.Close();
            }
        }
    }
}
