using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System;

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
    }
}
