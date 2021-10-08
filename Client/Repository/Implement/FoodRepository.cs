using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Client.Repository.Interface;
using Common.DAO;

namespace Client.Repository.Implement
{
    public class FoodRepository : IFoodRepository
    {
        //private TcpClient client;
        //private NetworkStream stream;
        //private StreamReader reader;
        //private StreamWriter writer;

        private List<Food> list = new List<Food>();
        public FoodRepository()
        {
            list.AddRange(new Food[]{
                new Food{Id=1,Name="Trung chien",Price=10000,Description="Ngon",Image=new byte[5]},
                new Food{Id=2,Name="Ca chien",Price=15000,Description="Ngon",Image=new byte[5]},
                new Food{Id=3,Name="Thit chien",Price=12000,Description="Ngon",Image=new byte[5]},
                new Food{Id=4,Name="Rau xao",Price=7000,Description="Ngon",Image=new byte[5]},
                new Food{Id=5,Name="Canh ca chua",Price=1000,Description="Ngon",Image=new byte[5]},
            });
        }

        public async Task<IEnumerable<Food>> GetAllAsync()
        {
            return await Task.Run(() => list.Where(c => true));
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

        public async Task<bool> UpdateAsync(int Id, Food obj)
        {
            Food f = list.Where(c=>c.Id==Id).FirstOrDefault();
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