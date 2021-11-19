using Microsoft.Extensions.Configuration;
using Client.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Entities;
using Common.Extension;
using Newtonsoft.Json;
using System;

namespace Client.Repository.Implement
{
    public class FoodRepository : Repository, IFoodRepository
    {
        public FoodRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<List<Food>> GetAllAsync()
        {
            string response = await SendAndReceiveAsync(Constant.Get_All_Food, "");
            return response != "" ? JsonConvert.DeserializeObject<List<Food>>(response) : null;
        }

        public async Task<Food> GetAsync(int Id)
        {
            string response = await SendAndReceiveAsync(Constant.Get_Food_By_Id, Id.ToString());
            return response != "" ? JsonConvert.DeserializeObject<Food>(response) : null;
        }

        public async Task<bool> CreateAsync(Food obj)
        {
            string food = JsonConvert.SerializeObject(obj);
            string response = await SendAndReceiveAsync(Constant.Create_Food, food);
            return response != "" ? Convert.ToBoolean(response) : false;
        }

        public async Task<bool> UpdateAsync(Food obj)
        {
            string food = JsonConvert.SerializeObject(obj);
            string response = await SendAndReceiveAsync(Constant.Update_Food, food);
            return response != "" ? Convert.ToBoolean(response) : false;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            string response = await SendAndReceiveAsync(Constant.Delete_Food, Id.ToString());
            return response != "" ? Convert.ToBoolean(response) : false;
        }
    }
}