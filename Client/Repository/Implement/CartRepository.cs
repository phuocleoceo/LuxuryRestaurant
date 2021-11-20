using Microsoft.Extensions.Configuration;
using Client.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Extension;
using Newtonsoft.Json;
using Common.Entities;
using System;

namespace Client.Repository.Implement
{
    public class CartRepository : Repository, ICartRepository
    {
        public CartRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<List<ShoppingCart>> GetCarts(int UserId)
        {
            string response = await SendAndReceiveAsync(Constant.Get_Carts, UserId.ToString());
            return response != null ? JsonConvert.DeserializeObject<List<ShoppingCart>>(response) : null;
        }

        public async Task<bool> AddToCart(ShoppingCart cart)
        {
            string newCart = JsonConvert.SerializeObject(cart);
            string response = await SendAndReceiveAsync(Constant.Add_To_Cart, newCart);
            return response != null ? Convert.ToBoolean(response) : false;
        }

        public async Task<bool> PlusCart(int cartId)
        {
            string response = await SendAndReceiveAsync(Constant.Plus_Cart, cartId.ToString());
            return response != null ? Convert.ToBoolean(response) : false;
        }

        public async Task<bool> MinusCart(int cartId)
        {
            string response = await SendAndReceiveAsync(Constant.Minus_Cart, cartId.ToString());
            return response != null ? Convert.ToBoolean(response) : false;
        }

        public async Task<bool> RemoveCart(int cartId)
        {
            string response = await SendAndReceiveAsync(Constant.Remove_Cart, cartId.ToString());
            return response != null ? Convert.ToBoolean(response) : false;
        }
    }
}
