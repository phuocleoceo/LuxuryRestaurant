using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DAO
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }

        //public int UserId { get; set; }
        //[ForeignKey(nameof(UserId))]
        //public User User { get; set; }

        public int FoodId { get; set; }
        [ForeignKey(nameof(FoodId))]
        public Food Food { get; set; }

        public int OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }

        public int Count { get; set; } = 1;
    }
}
