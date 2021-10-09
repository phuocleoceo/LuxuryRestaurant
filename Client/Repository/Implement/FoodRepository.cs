using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Client.Repository.Interface;
using Newtonsoft.Json;
using Common.DAO;
using Common.BO;
using Common.Extension;

namespace Client.Repository.Implement
{
    public class FoodRepository : IFoodRepository
    {
        private TcpClient client;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;

        private async Task InitStream()
        {
            client = new TcpClient();
            await client.ConnectAsync(IPAddress.Parse("127.0.0.1"), 1308);
            stream = client.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream) { AutoFlush = true };
        }

        public async Task<List<Food>> GetAllAsync()
        {
            try
            {
                await InitStream();
                RequestModel<int> rm = new RequestModel<int>
                {
                    Header = Constant.Get_All_Food,
                    Payload = 0
                };
                string rmJson = JsonConvert.SerializeObject(rm);
                await writer.WriteLineAsync(rmJson);

                string response = await reader.ReadLineAsync();
                return JsonConvert.DeserializeObject<List<Food>>(response);
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

        public async Task<Food> GetAsync(int Id)
        {
            try
            {
                await InitStream();
                RequestModel<int> rm = new RequestModel<int>
                {
                    Header = Constant.Get_Food_By_Id,
                    Payload = Id
                };
                string rmJson = JsonConvert.SerializeObject(rm);
                await writer.WriteLineAsync(rmJson);

                string response = await reader.ReadLineAsync();
                return JsonConvert.DeserializeObject<Food>(response);
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

        public async Task<bool> CreateAsync(Food obj)
        {
            try
            {
                await InitStream();
                RequestModel<Food> rm = new RequestModel<Food>
                {
                    Header = Constant.Create_Food,
                    Payload = obj
                };
                string rmJson = JsonConvert.SerializeObject(rm);
                await writer.WriteLineAsync(rmJson);

                string response = await reader.ReadLineAsync();            
                return JsonConvert.DeserializeObject<bool>(response);
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

        public async Task<bool> UpdateAsync(Food obj)
        {
            try
            {
                await InitStream();
                RequestModel<Food> rm = new RequestModel<Food>
                {
                    Header = Constant.Update_Food,
                    Payload = obj
                };
                string rmJson = JsonConvert.SerializeObject(rm);
                await writer.WriteLineAsync(rmJson);

                string response = await reader.ReadLineAsync();
                return JsonConvert.DeserializeObject<bool>(response);
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

        public async Task<bool> DeleteAsync(int Id)
        {
            try
            {
                await InitStream();
                RequestModel<int> rm = new RequestModel<int>
                {
                    Header = Constant.Delete_Food,
                    Payload = Id
                };
                string rmJson = JsonConvert.SerializeObject(rm);
                await writer.WriteLineAsync(rmJson);

                string response = await reader.ReadLineAsync();
                return JsonConvert.DeserializeObject<bool>(response);
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