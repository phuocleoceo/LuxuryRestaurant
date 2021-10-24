using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.DAO
{
    public class OrderHeader
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public double OrderTotal { get; set; }

        public DateTime? OrderDate { get; set; }

        public bool IsPaid { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public OrderHeader()
        {
            OrderDetails = new List<OrderDetail>();
        }
    }
}
