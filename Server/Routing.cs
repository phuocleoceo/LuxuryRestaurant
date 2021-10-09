using Server.Repository.Implement;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Extension;
using Newtonsoft.Json;
using Common.DAO;
using Common.BO;

namespace Server
{
    public class Routing
    {
        public static async Task<string> RouteAppRequest(RequestModel requestModel)
        {
            string response = "";
            switch (requestModel.Header)
            {
                case Constant.Get_All_Food:
                    List<Food> list = await(new FoodRepository()).GetAllAsync();
                    response = JsonConvert.SerializeObject(list);
                    break;
            }
            return response;
        }
    }
}
