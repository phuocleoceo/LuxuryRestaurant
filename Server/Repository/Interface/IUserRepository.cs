using System.Collections.Generic;
using System.Threading.Tasks;
using Common.DTO;
using Common.Entities;

namespace Server.Repository.Interface
{
	public interface IUserRepository
	{
		Task<User> LoginAsync(UserForLogin obj);

		Task<User> FindUserById(int UserId);

		Task<List<User>> LoadUserWithOrder();

		Task<bool> SaveAsync();
	}
}