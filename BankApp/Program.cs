using BankApp.Config;
using BankApp.Config.DI;
using BankApp.Helper;
using BankApp.Service;
using BankApp.View;
using BankAppData.Config;
using BankAppData.DB;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace BankApp
{
    static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Creation of the DI container
            var serviceCollection = new ServiceCollection();
            ServiceConfiguration.ConfigureServices(ref serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();

            // Set the connection string
            Session.Instance.ConnectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

            // Handle unhandled exceptions
            Application.ThreadException += new ThreadExceptionEventHandler((sender, e) =>
            {
                MessageBox.Show(e.Exception.Message, Constants.MsgBoxTitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            });

            Application.EnableVisualStyles(); 
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();

            // Navigate to the login view
            var navigationService = ServiceProvider.GetRequiredService<IViewNavigationService>();
            navigationService.NavigateTo(nameof(loginView));

            Application.Run();
        }
    }
}