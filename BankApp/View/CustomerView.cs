using BankApp.Helper;
using BankApp.ViewModel;

namespace BankApp.View
{
    public partial class CustomerView : Form
    {
        private readonly CustomerVM _viewModel;
        private readonly ErrorProvider _errorProvider;

        public CustomerView(CustomerVM viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
            InitializeBindings();

            _errorProvider = new();
            BindErrorProvider();
        }

        /// <summary>
        /// Manually bind the view model to the view, sadly this is not WPF
        /// </summary>
        private void InitializeBindings()
        {
            this.Load += (s, e) => _viewModel.OnLoadCmd.Execute(null);
            searchCustomerBtn.Click += (s, e) => _viewModel.SearchCustomerCmd.Execute(null);
            showPasswordBtn.Click += (s, e) => _viewModel.SeePasswordCmd.Execute(null);
            newBtn.Click += (s, e) => _viewModel.NewCmd.Execute(null);
            saveBtn.Click += (s, e) => _viewModel.SaveCmd.Execute(null);
            deleteBtn.Click += (s, e) => _viewModel.DeleteCmd.Execute(null);
            showAccsBtn.Click += (s, e) => _viewModel.ShowAccountsCmd.Execute(null);
            BindingHelper.BindNullableToControl(searchCustomerTxtBox, _viewModel, "Text", "CustomerId");
            BindingHelper.BindToControl(firstNameTxtBox, _viewModel, "Text", "Form.FirstName");
            BindingHelper.BindToControl(lastNameTxtBox, _viewModel, "Text", "Form.LastName");
            BindingHelper.BindToControl(usernameTxtBox, _viewModel, "Text", "Form.Username");
            BindingHelper.BindToControl(passwordTxtBox, _viewModel, "Text", "Form.Password");
            BindingHelper.BindToControl(passwordTxtBox, _viewModel, "UseSystemPasswordChar", "HidePassword");
            BindingHelper.BindToControl(countryTxtBox, _viewModel, "Text", "Form.Country");
            BindingHelper.BindToControl(regionTxtBox, _viewModel, "Text", "Form.Region");
            BindingHelper.BindToControl(cityTxtBox, _viewModel, "Text", "Form.City");
            BindingHelper.BindToControl(addressTxtBox, _viewModel, "Text", "Form.Address");
            BindingHelper.BindToControl(showPasswordBtn, _viewModel, "Text", "PasswordButtonText");

            BindingHelper.BindNullableToControl(saveBtn, _viewModel, "Enabled", "CanBeSaved");
            BindingHelper.BindNullableToControl(deleteBtn, _viewModel, "Enabled", "CanBeDeleted");
        }

        /// <summary>
        /// Binds the error provider to the controls.
        /// </summary>
        private void BindErrorProvider()
        {
            firstNameTxtBox.Validating += (s, e) => SetError(firstNameTxtBox, nameof(_viewModel.Form.FirstName));
            lastNameTxtBox.Validating += (s, e) => SetError(lastNameTxtBox, nameof(_viewModel.Form.LastName));
            usernameTxtBox.Validating += (s, e) => SetError(usernameTxtBox, nameof(_viewModel.Form.Username));
            passwordTxtBox.Validating += (s, e) => SetError(passwordTxtBox, nameof(_viewModel.Form.Password));
            countryTxtBox.Validating += (s, e) => SetError(countryTxtBox, nameof(_viewModel.Form.Country));
            regionTxtBox.Validating += (s, e) => SetError(regionTxtBox, nameof(_viewModel.Form.Region));
            cityTxtBox.Validating += (s, e) => SetError(cityTxtBox, nameof(_viewModel.Form.City));
            addressTxtBox.Validating += (s, e) => SetError(addressTxtBox, nameof(_viewModel.Form.Address));
        }

        /// <summary>
        /// Sets the error message for the control.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="propertyName"></param>
        private void SetError(Control control, string propertyName)
        {
            var error = _viewModel[propertyName];
            _errorProvider.SetError(control, error);
        }

    }
}
