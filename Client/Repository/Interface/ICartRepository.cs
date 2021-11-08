using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Repository.Interface
{
    public interface ICartRepository
    {
        Task<List<ShoppingCart>> GetCarts(int UserId);

        Task<bool> AddToCart(ShoppingCart cart);

        Task<bool> PlusCart(int cartId);

        Task<bool> MinusCart(int cartId);

        Task<bool> RemoveCart(int cartId);
    }
}
