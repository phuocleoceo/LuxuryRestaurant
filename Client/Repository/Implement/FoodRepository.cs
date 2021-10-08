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

        public Task<IEnumerable<Food>> GetAllAsync()
        {
            return Task.Run(() => list.Where(c => true));
        }

        public Task<Food> GetAsync(int Id)
        {
            return Task.Run(() => list[0]);
        }

        public Task<bool> CreateAsync(Food obj)
        {
            list.Add(obj);
            return Task.Run(() => true);
        }

        public Task<bool> UpdateAsync(int Id, Food obj)
        {
            Food f = list.Where(c=>c.Id==Id).FirstOrDefault();
            f.Name = obj.Name;
            f.Description = obj.Description;
            f.Price = obj.Price;
            return Task.Run(() => true);
        }

        public Task<bool> DeleteAsync(int Id)
        {
            Food f = list.Where(c => c.Id == Id).FirstOrDefault();
            list.Remove(f);
            return Task.Run(() => true);
        }
    }
}