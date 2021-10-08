using Microsoft.EntityFrameworkCore;
using Server.Data.Configuration;
using Common.DAO;
using Microsoft.Extensions.Configuration;

namespace Server.Data
{
    public class LuxuryContext : DbContext
    {
        private readonly string CNS = @"Server=(LocalDB)\MSSQLLocalDB;Database=LuxuryRestaurant;
                            Trusted_Connection=True;MultipleActiveResultSets=true";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CNS);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FoodConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
