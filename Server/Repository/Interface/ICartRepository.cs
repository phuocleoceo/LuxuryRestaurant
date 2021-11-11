using Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Repository.Interface
{
    public interface ICartRepository
    {
        Task<List<ShoppingCart>> GetCarts(int UserId);

        Task<bool> AddToCart(ShoppingCart cart);

        Task<bool> PlusCart(int cartId);

        Task<bool> MinusCart(int cartId);

        Task<bool> RemoveCart(int cartId);

        Task<bool> SaveAsync();
    }
}
