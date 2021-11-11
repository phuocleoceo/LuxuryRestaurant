using Common.Entities;
using Microsoft.EntityFrameworkCore;
using Server.Data.Configuration;

namespace Server.Data
{
    public class LuxuryContext : DbContext
    {
        private readonly string CNS = @"Server=(LocalDB)\MSSQLLocalDB;Database=LuxuryRestaurant;
                            Trusted_Connection=True;MultipleActiveResultSets=true";
        //private readonly string CNS = @"workstation id=LuxuryRestaurant.mssql.somee.com;
        //                                packet size=4096;user id=phuocleoceo_SQLLogin_1;
        //                                pwd=8q9d4uns68;
        //                                data source=LuxuryRestaurant.mssql.somee.com;
        //                                persist security info=False;
        //                                initial catalog=LuxuryRestaurant";

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
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
    }
}
