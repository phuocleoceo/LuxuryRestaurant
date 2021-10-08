using System.Threading.Tasks;
using Common.BO;
using Common.DAO;

namespace Server.Repository.Interface
{
	public interface IUserRepository
	{
		Task<User> LoginAsync(UserForLogin obj);

		Task<bool> SaveAsync();
	}
}