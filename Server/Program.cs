using Microsoft.Extensions.DependencyInjection;
using Server.Repository.Implement;
using Server.Repository.Interface;
using System.Windows.Forms;
using System;

namespace Server
{
    static class Program
    {
        public static IServiceProvider ServiceProvider { get; set; }

        static void ConfigureServices()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IFoodRepository, FoodRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            ServiceProvider = services.BuildServiceProvider();
        }

        public static T GetService<T>() where T : class
        {
            return (T)ServiceProvider.GetService(typeof(T));
        }

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConfigureServices();
            Application.Run(new FormMain());
        }
    }
}
