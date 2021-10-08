using System.Collections.Generic;
using System.Threading.Tasks;
using Common.DAO;

namespace Client.Repository.Interface
{
	public interface IFoodRepository
	{
		Task<IEnumerable<Food>> GetAllAsync();

		Task<Food> GetAsync(int Id);

		Task<bool> CreateAsync(Food obj);

		Task<bool> UpdateAsync(int id, Food obj);

		Task<bool> DeleteAsync(int Id);
	}
}