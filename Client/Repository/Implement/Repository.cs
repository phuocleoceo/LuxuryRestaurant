using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Repository.Interface;

namespace Client.Repository.Implement
{
	public class Repository<T> : IRepository<T> where T : class
	{
		public Task<IEnumerable<T>> GetAllAsync()
		{
			throw new System.NotImplementedException();
		}
		public Task<T> GetAsync(int Id)
		{
			throw new System.NotImplementedException();
		}
		public Task<bool> CreateAsync(T obj)
		{
			throw new System.NotImplementedException();
		}

		public Task<bool> UpdateAsync(int id, T obj)
		{
			throw new System.NotImplementedException();
		}

		public Task<bool> DeleteAsync(int Id)
		{
			throw new System.NotImplementedException();
		}
	}
}