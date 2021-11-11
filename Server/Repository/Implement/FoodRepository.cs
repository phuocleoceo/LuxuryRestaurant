using Common.Entities;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Repository.Implement
{
    public class FoodRepository : IFoodRepository
    {
        private readonly LuxuryContext _db;
        public FoodRepository()
        {
            _db = new LuxuryContext();
        }

        public async Task<List<Food>> GetAllAsync()
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

        public async Task<bool> UpdateAsync(Food obj)
        {
            _db.Foods.Update(obj);
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