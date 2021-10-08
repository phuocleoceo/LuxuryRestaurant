using System.Threading.Tasks;
using Common.BO;
using Common.DAO;

namespace Client.Repository.Interface
{
	public interface IUserRepository
	{
		Task<bool> LoginAsync(UserForLogin obj);
	}
}