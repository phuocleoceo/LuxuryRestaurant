using Client.Repository.Interface;
using System.Threading.Tasks;
using System.Net.Sockets;
using Common.Extension;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using Common.DTO;
using Common.Entities;

namespace Client.Repository.Implement
{
    public class UserRepository : IUserRepository
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

        public async Task<User> LoginAsync(UserForLogin obj)
        {
            try
            {
                await InitStream();
                RequestModel rm = new RequestModel
                {
                    Header = Constant.Login,
                    Payload = JsonConvert.SerializeObject(obj)
                };
                string rmJson = JsonConvert.SerializeObject(rm);
                await writer.WriteLineAsync(rmJson);

                string response = await reader.ReadLineAsync();
                return JsonConvert.DeserializeObject<User>(response);
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