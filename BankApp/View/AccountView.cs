using BankApp.Helper;
using BankApp.ViewModel;
using BankApp.ViewModel.Base;

namespace BankApp.View
{
    public partial class AccountView : Form, IParameterReciever
    {
        private readonly AccountVM _viewModel;

        public AccountView(AccountVM viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
            InitializeBindings();
        }

        public void ReceiveParameter(object parameter)
        {
            _viewModel.CustomerId = (int)parameter;
        }

        /// <summary>
        /// Manually bind the view model to the view, sadly this is not WPF
        /// </summary>
        private void InitializeBindings()
        {
            Load += (s, e) => _viewModel.OnLoadCmd.Execute(null);
            BindingHelper.BindCollectionToDataGridView(accountsDataGridView, _viewModel.Rows);
        }
    }
}
