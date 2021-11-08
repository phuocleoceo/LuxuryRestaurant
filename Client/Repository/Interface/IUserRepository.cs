using System.Threading.Tasks;
using Common.DTO;
using Common.Entities;

namespace Client.Repository.Interface
{
	public interface IUserRepository
	{
		Task<User> LoginAsync(UserForLogin obj);
	}
}