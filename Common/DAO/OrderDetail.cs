using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DAO
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }

        public int FoodId { get; set; }
        [ForeignKey(nameof(FoodId))]
        public Food Food { get; set; }

        public int OrderHeaderId { get; set; }
        [ForeignKey(nameof(OrderHeaderId))]
        public OrderHeader OrderHeader { get; set; }

        public int Count { get; set; }

        public double Price { get; set; }
    }
}
