using Common.DAO;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Repository.Implement
{
    public class OrderRepository : IOrderRepository
    {
        private readonly LuxuryContext _db;
        public OrderRepository()
        {
            _db = new LuxuryContext();
        }

        public async Task<bool> PlaceOrder(int UserId)
        {
            OrderHeader orderHeader = new OrderHeader()
            {
                UserId = UserId,
                OrderDate = DateTime.Now,
                IsPaid = false
            };
            await _db.OrderHeaders.AddAsync(orderHeader);
            await _db.SaveChangesAsync();

            await _db.ShoppingCarts.Where(c => c.UserId == UserId)
                .Include(c => c.Food).ForEachAsync(c=>
                {
                    OrderDetail orderDetail = new OrderDetail()
                    {
                        FoodId = c.FoodId,
                        OrderHeaderId = orderHeader.Id,
                        Price = c.Food.Price,
                        Count = c.Count
                    };
                    orderHeader.OrderTotal += orderDetail.Count * orderDetail.Price;
                    _db.OrderDetails.Add(orderDetail);
                    _db.ShoppingCarts.Remove(c);
                });
            return await SaveAsync();
        }

        public async Task<OrderHeader> GetOrderOfUser(int UserId)
        {
            return await _db.OrderHeaders
                .FirstOrDefaultAsync(c => c.UserId == UserId && !c.IsPaid);
        }

        public async Task<List<OrderDetail>> GetOrderDetail(int OrderHeaderId)
        {
            return await _db.OrderDetails.Include(c => c.Food)
                    .Where(c => c.OrderHeaderId == OrderHeaderId).ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _db.SaveChangesAsync() >= 0;
        }
    }
}
