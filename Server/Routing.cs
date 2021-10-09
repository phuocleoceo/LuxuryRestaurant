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
                    response = JsonConvert.SerializeObject(fc_success);
                    break;
                case Constant.Update_Food:
                    Food fu = JsonConvert.DeserializeObject<Food>(requestModel.Payload);
                    bool fu_success = await fr.UpdateAsync(fu);
                    response = JsonConvert.SerializeObject(fu_success);
                    break;
                case Constant.Delete_Food:
                    int d_id = Convert.ToInt32(requestModel.Payload);
                    bool fd_success = await fr.DeleteAsync(d_id);
                    response = JsonConvert.SerializeObject(fd_success);
                    break;
            }
            return response;
        }
    }
}
