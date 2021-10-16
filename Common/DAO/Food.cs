using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Common.DAO
{
	public class Food
	{
		[Key]
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public double Price { get; set; }

		public byte[] Image { get; set; }

		public ICollection<ShoppingCart> ShoppingCarts { get; set; }

		public Food()
		{
			ShoppingCarts = new List<ShoppingCart>();
		}
	}
}