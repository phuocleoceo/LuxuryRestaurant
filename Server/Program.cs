using Microsoft.Extensions.DependencyInjection;
using Server.Repository.Implement;
using Server.Repository.Interface;
using System.Windows.Forms;
using System;

namespace Server
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
