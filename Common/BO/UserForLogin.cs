using System.ComponentModel.DataAnnotations;

namespace Common.BO
{
	public class UserForLogin
	{
		[Required]
		public string UserName { get; set; }

		[Required]
		public string Password { get; set; }
	}
}