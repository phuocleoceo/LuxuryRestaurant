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

        private List<Food> list = new List<Food>();

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
                string rmjson = JsonConvert.SerializeObject(rm);
                await writer.WriteLineAsync(rmjson);

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
            return await Task.Run(() => list[0]);
        }

        public async Task<bool> CreateAsync(Food obj)
        {
            list.Add(obj);
            return await Task.Run(() => true);
        }

        public async Task<bool> UpdateAsync(Food obj)
        {
            Food f = list.Where(c=>c.Id==obj.Id).FirstOrDefault();
            f.Name = obj.Name;
            f.Description = obj.Description;
            f.Price = obj.Price;
            return await Task.Run(() => true);
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            Food f = list.Where(c => c.Id == Id).FirstOrDefault();
            list.Remove(f);
            return await Task.Run(() => true);
        }
    }
}