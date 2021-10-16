using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Common.DAO
{
	public class User
	{
		[Key]
		public int Id { get; set; }

		public string UserName { get; set; }

		public string DisplayName { get; set; }

		public string Password { get; set; }

		public string Role { get; set; }

		public ICollection<ShoppingCart> ShoppingCarts { get; set; }

		public ICollection<Order> Orders { get; set; }

		public User()
		{
			ShoppingCarts = new List<ShoppingCart>();
			Orders = new List<Order>();
		}
	}
}