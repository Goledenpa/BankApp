using BankApp.Base;
using BankApp.Facade.Login;
using BankApp.Model;
using BankApp.Service;
using BankApp.View;
using BankApp.ViewModel.Base;
using BankAppData.Config;

namespace BankApp.ViewModel
{
    public class LoginVM : BaseVM<LoginForm>
    {
        #region Properties

        protected new readonly ILoginFacade _facade;


        #region Commands

        public RelayCommand LoginCmd { get; set; }

        #endregion

        #endregion

        public LoginVM(IViewNavigationService navigationService, ILoginFacade loginFacade) : base(navigationService,loginFacade)
        {
            _facade = loginFacade;
            InitializeCommands();
        }

        protected override void InitializeCommands()
        {
            LoginCmd = new (x => Login(), x => CanLogin());
        }

        #region Commands

        private bool CanLogin()
        {
            return !string.IsNullOrEmpty(Form.Username) && !string.IsNullOrEmpty(Form.Password);
        }

        private void Login()
        {
            if (_facade.Login(Form))
            {
                // Set the actual user that is using the app to the logged one
                Session.Instance.LoggedCustomerId = Form.Id;

                _navigationService.NavigateTo(nameof(CustomerView));
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }

        #endregion
    }
}
