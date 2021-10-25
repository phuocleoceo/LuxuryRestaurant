using Server.Repository.Implement;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Extension;
using Newtonsoft.Json;
using Common.DAO;
using Common.BO;
using System;

namespace Server
{
    public class Routing
    {
        public static async Task<string> RouteAppRequest(RequestModel requestModel)
        {
            string response = "";
            string header = requestModel.Header;
            if (header.EndsWith("Food")) response = await RoutingFood(requestModel);
            if (header.EndsWith("User")) response = await RoutingUser(requestModel);
            if (header.EndsWith("Cart")) response = await RoutingCart(requestModel);
            if (header.EndsWith("Order")) response = await RoutingOrder(requestModel);
            return response;
        }

        public static async Task<string> RoutingFood(RequestModel requestModel)
        {
            string response = "";
            FoodRepository fr = new FoodRepository();
            switch (requestModel.Header)
            {
                case Constant.Get_All_Food:
                    List<Food> list = await fr.GetAllAsync();
                    response = JsonConvert.SerializeObject(list);
                    break;
                case Constant.Get_Food_By_Id:
                    int f_id = Convert.ToInt32(requestModel.Payload);
                    Food f = await fr.GetAsync(f_id);
                    response = JsonConvert.SerializeObject(f);
                    break;
                case Constant.Create_Food:
                    Food fc = JsonConvert.DeserializeObject<Food>(requestModel.Payload);
                    bool fc_success = await fr.CreateAsync(fc);
                    response = fc_success.ToString();
                    break;
                case Constant.Update_Food:
                    Food fu = JsonConvert.DeserializeObject<Food>(requestModel.Payload);
                    bool fu_success = await fr.UpdateAsync(fu);
                    response = fu_success.ToString();
                    break;
                case Constant.Delete_Food:
                    int d_id = Convert.ToInt32(requestModel.Payload);
                    bool fd_success = await fr.DeleteAsync(d_id);
                    response = fd_success.ToString();
                    break;
            }
            return response;
        }

        public static async Task<string> RoutingUser(RequestModel requestModel)
        {
            string response = "";
            UserRepository ur = new UserRepository();
            switch (requestModel.Header)
            {
                case Constant.Login:
                    UserForLogin userFG = JsonConvert.DeserializeObject<UserForLogin>(requestModel.Payload);
                    User user = await ur.LoginAsync(userFG);
                    response = JsonConvert.SerializeObject(user);
                    break;
            }
            return response;
        }

        public static async Task<string> RoutingCart(RequestModel requestModel)
        {
            string response = "";
            CartRepository cr = new CartRepository();
            switch (requestModel.Header)
            {
                case Constant.Get_Carts:
                    int UserId = Convert.ToInt32(requestModel.Payload);
                    List<ShoppingCart> listCart = await cr.GetCarts(UserId);
                    response = JsonConvert.SerializeObject(listCart);
                    break;
                case Constant.Add_To_Cart:
                    ShoppingCart cart = JsonConvert.DeserializeObject<ShoppingCart>(requestModel.Payload);
                    bool atc_success = await cr.AddToCart(cart);
                    response = atc_success.ToString();
                    break;
                case Constant.Plus_Cart:
                    int p_cartId = Convert.ToInt32(requestModel.Payload);
                    bool p_success = await cr.PlusCart(p_cartId);
                    response = p_success.ToString();
                    break;
                case Constant.Minus_Cart:
                    int m_cartId = Convert.ToInt32(requestModel.Payload);
                    bool m_success = await cr.MinusCart(m_cartId);
                    response = m_success.ToString();
                    break;
                case Constant.Remove_Cart:
                    int r_cartId = Convert.ToInt32(requestModel.Payload);
                    bool r_success = await cr.RemoveCart(r_cartId);
                    response = r_success.ToString();
                    break;
            }
            return response;
        }

        public static async Task<string> RoutingOrder(RequestModel requestModel)
        {
            string response = "";
            OrderRepository or = new OrderRepository();
            switch (requestModel.Header)
            {
                case Constant.Place_Order:
                    int po_userId = Convert.ToInt32(requestModel.Payload);
                    bool po_success = await or.PlaceOrder(po_userId);
                    response = po_success.ToString();
                    break;
            }
            return response;
        }
    }
}
