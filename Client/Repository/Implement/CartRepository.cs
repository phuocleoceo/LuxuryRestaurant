using Client.Repository.Interface;
using Common.DTO;
using Common.Entities;
using Common.Extension;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Repository.Implement
{
    public class CartRepository : Repository, ICartRepository
    {
        public CartRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<List<ShoppingCart>> GetCarts(int UserId)
        {
            try
            {
                await InitStream();
                RequestModel rm = new RequestModel
                {
                    Header = Constant.Get_Carts,
                    Payload = UserId.ToString()
                };
                string rmJson = JsonConvert.SerializeObject(rm);
                await writer.WriteLineAsync(rmJson);

                string response = await reader.ReadLineAsync();
                return JsonConvert.DeserializeObject<List<ShoppingCart>>(response);
            }
            catch
            {
                return null;
            }
            finally
            {
                stream.Close();
                client.Close();
            }
        }

        public async Task<bool> AddToCart(ShoppingCart cart)
        {
            try
            {
                await InitStream();
                RequestModel rm = new RequestModel
                {
                    Header = Constant.Add_To_Cart,
                    Payload = JsonConvert.SerializeObject(cart)
                };
                string rmJson = JsonConvert.SerializeObject(rm);
                await writer.WriteLineAsync(rmJson);

                string response = await reader.ReadLineAsync();
                return Convert.ToBoolean(response);
            }
            catch
            {
                return false;
            }
            finally
            {
                stream.Close();
                client.Close();
            }
        }

        public async Task<bool> PlusCart(int cartId)
        {
            try
            {
                await InitStream();
                RequestModel rm = new RequestModel
                {
                    Header = Constant.Plus_Cart,
                    Payload = cartId.ToString()
                };
                string rmJson = JsonConvert.SerializeObject(rm);
                await writer.WriteLineAsync(rmJson);

                string response = await reader.ReadLineAsync();
                return Convert.ToBoolean(response);
            }
            catch
            {
                return false;
            }
            finally
            {
                stream.Close();
                client.Close();
            }
        }

        public async Task<bool> MinusCart(int cartId)
        {
            try
            {
                await InitStream();
                RequestModel rm = new RequestModel
                {
                    Header = Constant.Minus_Cart,
                    Payload = cartId.ToString()
                };
                string rmJson = JsonConvert.SerializeObject(rm);
                await writer.WriteLineAsync(rmJson);

                string response = await reader.ReadLineAsync();
                return Convert.ToBoolean(response);
            }
            catch
            {
                return false;
            }
            finally
            {
                stream.Close();
                client.Close();
            }
        }

        public async Task<bool> RemoveCart(int cartId)
        {
            try
            {
                await InitStream();
                RequestModel rm = new RequestModel
                {
                    Header = Constant.Remove_Cart,
                    Payload = cartId.ToString()
                };
                string rmJson = JsonConvert.SerializeObject(rm);
                await writer.WriteLineAsync(rmJson);

                string response = await reader.ReadLineAsync();
                return Convert.ToBoolean(response);
            }
            catch
            {
                return false;
            }
            finally
            {
                stream.Close();
                client.Close();
            }
        }
    }
}
