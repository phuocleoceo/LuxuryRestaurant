﻿using Common.DTO;
using Common.Entities;
using Common.Extension;
using Newtonsoft.Json;
using Server.Repository.Implement;
using Server.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server
{
    public class Routing
    {
        private readonly IFoodRepository _fr;
        private readonly IUserRepository _ur;
        private readonly ICartRepository _cr;
        private readonly IOrderRepository _or;
        public Routing()
        {
            _fr = new FoodRepository();
            _ur = new UserRepository();
            _cr = new CartRepository();
            _or = new OrderRepository();
        }

        public async Task<string> RouteAppRequest(RequestModel requestModel)
        {
            string response = "";
            string header = requestModel.Header;
            if (header.EndsWith("Food")) response = await RoutingFood(requestModel);
            if (header.EndsWith("User")) response = await RoutingUser(requestModel);
            if (header.EndsWith("Cart")) response = await RoutingCart(requestModel);
            if (header.EndsWith("Order")) response = await RoutingOrder(requestModel);
            return response;
        }

        public async Task<string> RoutingFood(RequestModel requestModel)
        {
            string response = "";
            switch (requestModel.Header)
            {
                case Constant.Get_All_Food:
                    List<Food> list = await _fr.GetAllAsync();
                    response = JsonConvert.SerializeObject(list);
                    break;
                case Constant.Get_Food_By_Id:
                    int f_id = Convert.ToInt32(requestModel.Body);
                    Food f = await _fr.GetAsync(f_id);
                    response = JsonConvert.SerializeObject(f);
                    break;
                case Constant.Create_Food:
                    Food fc = JsonConvert.DeserializeObject<Food>(requestModel.Body);
                    bool fc_success = await _fr.CreateAsync(fc);
                    response = fc_success.ToString();
                    break;
                case Constant.Update_Food:
                    Food fu = JsonConvert.DeserializeObject<Food>(requestModel.Body);
                    bool fu_success = await _fr.UpdateAsync(fu);
                    response = fu_success.ToString();
                    break;
                case Constant.Delete_Food:
                    int d_id = Convert.ToInt32(requestModel.Body);
                    bool fd_success = await _fr.DeleteAsync(d_id);
                    response = fd_success.ToString();
                    break;
            }
            return response;
        }

        public async Task<string> RoutingUser(RequestModel requestModel)
        {
            string response = "";
            switch (requestModel.Header)
            {
                case Constant.Login:
                    UserForLogin userFG = JsonConvert.DeserializeObject<UserForLogin>(requestModel.Body);
                    User user = await _ur.LoginAsync(userFG);
                    response = JsonConvert.SerializeObject(user);
                    break;
            }
            return response;
        }

        public async Task<string> RoutingCart(RequestModel requestModel)
        {
            string response = "";
            switch (requestModel.Header)
            {
                case Constant.Get_Carts:
                    int UserId = Convert.ToInt32(requestModel.Body);
                    List<ShoppingCart> listCart = await _cr.GetCarts(UserId);
                    response = JsonConvert.SerializeObject(listCart);
                    break;
                case Constant.Add_To_Cart:
                    ShoppingCart cart = JsonConvert.DeserializeObject<ShoppingCart>(requestModel.Body);
                    bool atc_success = await _cr.AddToCart(cart);
                    response = atc_success.ToString();
                    break;
                case Constant.Plus_Cart:
                    int p_cartId = Convert.ToInt32(requestModel.Body);
                    bool p_success = await _cr.PlusCart(p_cartId);
                    response = p_success.ToString();
                    break;
                case Constant.Minus_Cart:
                    int m_cartId = Convert.ToInt32(requestModel.Body);
                    bool m_success = await _cr.MinusCart(m_cartId);
                    response = m_success.ToString();
                    break;
                case Constant.Remove_Cart:
                    int r_cartId = Convert.ToInt32(requestModel.Body);
                    bool r_success = await _cr.RemoveCart(r_cartId);
                    response = r_success.ToString();
                    break;
            }
            return response;
        }

        public async Task<string> RoutingOrder(RequestModel requestModel)
        {
            string response = "";
            switch (requestModel.Header)
            {
                case Constant.Place_Order:
                    int po_userId = Convert.ToInt32(requestModel.Body);
                    bool po_success = await _or.PlaceOrder(po_userId);
                    response = po_success.ToString();
                    break;
            }
            return response;
        }
    }
}
