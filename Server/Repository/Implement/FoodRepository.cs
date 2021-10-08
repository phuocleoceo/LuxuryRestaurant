using Microsoft.EntityFrameworkCore;
using Server.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Data;
using Common.DAO;

namespace Server.Repository.Implement
{
    public class FoodRepository : IFoodRepository
    {
        private readonly LuxuryContext _db;
        public FoodRepository()
        {
            _db = new LuxuryContext();
        }

        public async Task<IEnumerable<Food>> GetAllAsync()
        {
            return await _db.Foods.ToListAsync();
        }

        public async Task<Food> GetAsync(int Id)
        {
            return await _db.Foods.FindAsync(Id);
        }

        public async Task<bool> CreateAsync(Food obj)
        {
            await _db.Foods.AddAsync(obj);
            return await SaveAsync();
        }

        public async Task<bool> UpdateAsync(int Id, Food obj)
        {
            Food f = await GetAsync(Id);
            f.Name = obj.Name;
            f.Description = obj.Description;
            f.Price = obj.Price;
            return await SaveAsync();
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            Food f = await GetAsync(Id);
            _db.Foods.Remove(f);
            return await SaveAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _db.SaveChangesAsync() >= 0;
        }
    }
}