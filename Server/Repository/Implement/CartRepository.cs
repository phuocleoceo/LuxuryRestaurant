using Common.DAO;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Repository.Implement
{
    public class CartRepository : ICartRepository
    {
        private readonly LuxuryContext _db;
        public CartRepository()
        {
            _db = new LuxuryContext();
        }

        public async Task<List<ShoppingCart>> GetCarts(int UserId)
        {
            return await _db.ShoppingCarts.Include(c => c.Food)
                    .Where(c => c.UserId == UserId).ToListAsync();
        }

        public async Task<bool> AddToCart(ShoppingCart cart)
        {
            ShoppingCart scFromDB = await _db.ShoppingCarts.Include(c => c.Food)
                .FirstOrDefaultAsync(c => c.UserId == cart.UserId && c.FoodId == cart.FoodId);

            if (scFromDB == null)
            {
                await _db.ShoppingCarts.AddAsync(cart);
            }
            else
            {
                scFromDB.Count += cart.Count;
            }
            return await SaveAsync();
        }

        public async Task<bool> PlusCart(int cartId)
        {
            ShoppingCart cart = await _db.ShoppingCarts.FirstOrDefaultAsync(c => c.Id == cartId);
            if (cart == null) return false;
            cart.Count++;
            return await SaveAsync();
        }

        public async Task<bool> MinusCart(int cartId)
        {
            ShoppingCart cart = await _db.ShoppingCarts.FirstOrDefaultAsync(c => c.Id == cartId);
            if (cart == null || cart.Count <= 1) return false;
            //if (cart.Count == 1)
            //{
            //    _db.ShoppingCarts.Remove(cart);
            //}
            //else
            //{
            //    cart.Count--;
            //}
            cart.Count--;
            return await SaveAsync();
        }

        public async Task<bool> RemoveCart(int cartId)
        {
            ShoppingCart cart = await _db.ShoppingCarts.FirstOrDefaultAsync(c => c.Id == cartId);
            if (cart == null) return false;
            _db.ShoppingCarts.Remove(cart);
            return await SaveAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _db.SaveChangesAsync() >= 0;
        }
    }
}
