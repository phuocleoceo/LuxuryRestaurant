using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DAO
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public double OrderTotal { get; set; }

        public DateTime? OrderDate { get; set; }

        public bool IsPaid { get; set; }

        public ICollection<ShoppingCart> ShoppingCarts { get; set; }

        public Order()
        {
            ShoppingCarts = new HashSet<ShoppingCart>();
        }
    }
}
