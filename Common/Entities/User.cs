using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Common.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string DisplayName { get; set; }

        [Required]
        public string Password { get; set; }

        public string Role { get; set; }

        public ICollection<ShoppingCart> ShoppingCarts { get; set; }

        public ICollection<OrderHeader> OrderHeaders { get; set; }

        public User()
        {
            ShoppingCarts = new List<ShoppingCart>();
            OrderHeaders = new List<OrderHeader>();
        }
    }
}