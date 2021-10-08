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
		private TcpClient client;
		private NetworkStream stream;
		private StreamReader reader;
		private StreamWriter writer;

		public Task<IEnumerable<Food>> GetAllAsync()
		{
			List<Food> list = new List<Food>();
			list.AddRange(new Food[]{
				new Food{Id=1,Name="Trung chien",Price=10000,Description="Ngon",Image=new byte[5]},
				new Food{Id=2,Name="Ca chien",Price=15000,Description="Ngon",Image=new byte[5]},
				new Food{Id=3,Name="Thit chien",Price=12000,Description="Ngon",Image=new byte[5]},
				new Food{Id=4,Name="Rau xao",Price=7000,Description="Ngon",Image=new byte[5]},
				new Food{Id=5,Name="Canh ca chua",Price=1000,Description="Ngon",Image=new byte[5]},
			});
			return Task.Run(() => list.Where(c => true));
		}

		public Task<Food> GetAsync(int Id)
		{
			throw new System.NotImplementedException();
		}

		public Task<bool> CreateAsync(Food obj)
		{
			throw new System.NotImplementedException();
		}

		public Task<bool> UpdateAsync(int id, Food obj)
		{
			throw new System.NotImplementedException();
		}

		public Task<bool> DeleteAsync(int Id)
		{
			throw new System.NotImplementedException();
		}
	}
}