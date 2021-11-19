using Common.DTO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Client.Repository.Implement
{
    public class Repository
    {
        protected TcpClient client;
        protected NetworkStream stream;
        protected StreamReader reader;
        protected StreamWriter writer;

        protected readonly IConfiguration _configuration;
        protected IPAddress ip;
        protected int port;

        public Repository(IConfiguration configuration)
        {
            _configuration = configuration;
            ip = IPAddress.Parse(_configuration.GetSection("ServerInfor:IP").Value);
            port = Convert.ToInt32(_configuration.GetSection("ServerInfor:Port").Value);
        }

        public async Task InitStream()
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
                return "";
            }
            finally
            {
                stream.Close();
                client.Close();
            }
        }
    }
}
