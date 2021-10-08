using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Repository.Interface
{
	public interface IRepository<T> where T : class
	{
		Task<IEnumerable<T>> GetAllAsync();

		Task<T> GetAsync(int Id);

		Task<bool> CreateAsync(T obj);

		Task<bool> UpdateAsync(int id, T obj);

		Task<bool> DeleteAsync(int Id);
	}
}