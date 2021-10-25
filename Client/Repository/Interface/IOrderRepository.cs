using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Repository.Interface
{
    public interface IOrderRepository
    {
        Task<bool> PlaceOrder(int UserId);
    }
}
