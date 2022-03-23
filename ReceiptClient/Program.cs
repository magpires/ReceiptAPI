using Microsoft.Extensions.DependencyInjection;
using ReceiptClient.Controllers;
using ReceiptClient.Controllers.Interfaces;
using ReceiptClient.Services;
using ReceiptClient.Services.Interfaces;
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
        public static IServiceProvider serviceProvider { get; set; }

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
            //Build serviceprovider object
            serviceProvider = services.BuildServiceProvider();

            //Request instance service of MainForm type from service manager
            Application.Run(serviceProvider.GetService<FormLogin>());
        }

        public static void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<IAuthController, AuthController>();
            services.AddSingleton<IButtonEnableControl, ButtonEnableControl>();
            services.AddSingleton<FormLogin>();
            services.AddTransient<FormUserRegister>();
        }
    }
}
