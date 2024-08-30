using BankApp.Facade.Account;
using BankApp.Facade.Customer;
using BankApp.Facade.Login;
using BankApp.Service;
using BankApp.View;
using BankApp.ViewModel;
using BankAppData.Controller.Account;
using BankAppData.Controller.Customer;
using BankAppData.Controller.Login;
using BankAppData.DB;
using BankAppData.Repository.Account;
using BankAppData.Repository.Customer;
using BankAppData.Repository.Login;
using BankAppData.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Config.DI
{
    public static class ServiceConfiguration
    {
        // This method is used to configure the services of the application using Dependency Injection
        public static void ConfigureServices(ref ServiceCollection services)
        {
            services.AddDbContext<BankContext>();
            services.AddScoped<IUnitOfWork<BankContext>, UnitOfWork<BankContext>>();

            services.AddTransient<AccountView>();
            services.AddScoped<CustomerView>();
            services.AddScoped<loginView>();

            services.AddTransient<AccountVM>();
            services.AddScoped<CustomerVM>();
            services.AddScoped<LoginVM>();

            services.AddScoped<IAccountFacade, AccountFacade>();
            services.AddScoped<ICustomerFacade, CustomerFacade>();
            services.AddScoped<ILoginFacade, LoginFacade>();

            services.AddScoped<IAccountController, AccountController>();
            services.AddScoped<ICustomerController, CustomerController>();
            services.AddScoped<ILoginController, LoginController>();

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();

            services.AddSingleton<IViewNavigationService, ViewNavigationService>();
        }
    }
}
