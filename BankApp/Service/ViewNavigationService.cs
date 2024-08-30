using BankApp.View;
using BankApp.ViewModel.Base;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Service
{
    /// <summary>
    /// Service that allows navigation between views.
    /// </summary>
    public class ViewNavigationService : IViewNavigationService
    {

        private readonly IServiceProvider _serviceProvider;
        public Form CurrentForm { get; set; }

        public ViewNavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void NavigateTo(string name, object? parameter = null)
        {
            Form view = name switch
            {
                nameof(AccountView) => CreateAccountView(parameter),
                nameof(CustomerView) => _serviceProvider.GetRequiredService<CustomerView>(),
                nameof(loginView) => _serviceProvider.GetRequiredService<loginView>(),
                _ => throw new ArgumentException("Invalid view name", nameof(name))
            };

            if (view is not AccountView)
            {
                view.FormClosed += OnViewClosed;
            }
            else
            {
                // Show the account view as a dialog so it can be closed without closing the application.
                view.ShowDialog();
                return;
            }

            view.Show();
            CurrentForm?.Hide();

            CurrentForm = view;
        }

        /// <summary>
        /// Closes the application when the view is closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnViewClosed(object? sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Creates the account view with the given parameter, the parameter is always the CustomerId that the view is being created upon.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private AccountView CreateAccountView(object? parameter)
        {
            var accountView = _serviceProvider.GetRequiredService<AccountView>();
            if (parameter is not null && accountView is IParameterReciever parameterReciever)
            {
                parameterReciever.ReceiveParameter(parameter);
            }

            return accountView;
        }
    }
}
