using BankApp.Helper;
using BankApp.ViewModel;

namespace BankApp.View
{
    public partial class loginView : Form
    {
        private readonly LoginVM _viewModel;

        public loginView(LoginVM viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
            InitializeBindings();
        }

        /// <summary>
        /// Manually bind the view model to the view, sadly this is not WPF
        /// </summary>
        protected void InitializeBindings()
        {
            BindingHelper.BindToControl(loginTxtBox, _viewModel, "Text", "Form.Username");
            BindingHelper.BindToControl(passwordTxtBox, _viewModel, "Text", "Form.Password");
            loginBtn.Click += (s, e) => _viewModel.LoginCmd.Execute(null);
        }
    }
}
