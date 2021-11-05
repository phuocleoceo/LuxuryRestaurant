using Common.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Repository.Interface
{
    public interface IOrderRepository
    {
        Task<bool> PlaceOrder(int UserId);

        Task<OrderHeader> GetOrderOfUser(int UserId);

        Task<List<OrderDetail>> GetOrderDetail(int OrderHeaderId);

        Task<bool> PurchaseForUser(int UserId);

        Task<bool> SaveAsync();
    }
}
