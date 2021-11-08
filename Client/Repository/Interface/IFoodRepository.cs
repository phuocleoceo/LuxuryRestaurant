using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Entities;

namespace Client.Repository.Interface
{
	public interface IFoodRepository
	{
		Task<List<Food>> GetAllAsync();

		Task<Food> GetAsync(int Id);

		Task<bool> CreateAsync(Food obj);

		Task<bool> UpdateAsync(Food obj);

		Task<bool> DeleteAsync(int Id);
	}
}