using BankApp.Base;
using BankApp.Facade.Account;
using BankApp.Model;
using BankApp.Service;
using BankApp.ViewModel.Base;
using System.ComponentModel;

namespace BankApp.ViewModel
{
    public class AccountVM : BaseVM<AccountForm>
    {

        #region Properties

        private new readonly IAccountFacade _facade;

        public int CustomerId { get; set; }

        public BindingList<AccountForm> Rows { get; set; }

        #region Commands

        public RelayCommand OnLoadCmd { get; set; }

        #endregion

        #endregion

        public AccountVM(IViewNavigationService navigationService, IAccountFacade facade)
            : base(navigationService, facade)
        {
            _facade = facade;
            InitializeCommands();
            InitializeCollections();
        }

        protected override void InitializeCommands()
        {
            OnLoadCmd = new(x => Load(), x => true);
        }

        private void InitializeCollections()
        {
            Rows = [];
        }

        #region Commands

        private void Load()
        {
            var newRows = _facade.GetAll(CustomerId);

            // Gotta circle to all the rows and add them to the collection, if not, it doesnt update properly the UI
            foreach (var newRow in newRows)
            {
                Rows.Add(newRow);
            }
        }

        #endregion
    }
}
