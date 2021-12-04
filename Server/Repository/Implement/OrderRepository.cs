using Microsoft.EntityFrameworkCore;
using Server.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Entities;
using Server.Data;
using System.Linq;
using System;

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
                .Include(c => c.Food).ForEachAsync(c =>
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

        public async Task<List<OrderHeader>> GetOrderOfUser(int UserId)
        {
            return await _db.OrderHeaders
                .Where(c => c.UserId == UserId && !c.IsPaid).ToListAsync();
        }

        // Mỗi User có thể PlaceOrder nhiều lần nên ta cần lấy danh sách đặt món chi tiết
        // của nhiều OrderHeader
        public async Task<List<OrderDetail>> GetOrderDetail(List<OrderHeader> listOrder)
        {
            List<OrderDetail> listOrderDetail = new List<OrderDetail>();
            foreach (OrderHeader o in listOrder)
            {
                listOrderDetail.AddRange(await _db.OrderDetails.Include(c => c.Food)
                    .Where(c => c.OrderHeaderId == o.Id).ToListAsync());
            }
            return listOrderDetail;
        }

        public async Task<bool> PurchaseForUser(int UserId)
        {
            List<OrderHeader> order = await _db.OrderHeaders
                        .Where(c => c.UserId == UserId && !c.IsPaid).ToListAsync();
            for (int i = 0; i < order.Count; i++)
            {
                order[i].IsPaid = true;
            }
            return await SaveAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _db.SaveChangesAsync() >= 0;
        }
    }
}
