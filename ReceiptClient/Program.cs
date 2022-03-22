using Microsoft.Extensions.DependencyInjection;
using ReceiptClient.Controllers;
using ReceiptClient.Controllers.Interfaces;
using ReceiptClient.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReceiptClient
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            ConfigureServices(services);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var formLogin = serviceProvider.GetRequiredService<FormLogin>();
                Application.Run(formLogin);
            }
        }

        public static void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<IAuthController, AuthController>();
            services.AddScoped<FormLogin>();
        }
    }
}
