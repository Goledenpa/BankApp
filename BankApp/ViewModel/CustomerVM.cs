using BankApp.Base;
using BankApp.Config;
using BankApp.Facade.Customer;
using BankApp.Model;
using BankApp.Service;
using BankApp.View;
using BankApp.ViewModel.Base;
using BankAppData.Config;

namespace BankApp.ViewModel
{
    public class CustomerVM : SaveVM<CustomerForm>
    {
        #region Properties

        private new readonly ICustomerFacade _facade;

        private int? customerId;
        public int? CustomerId
        {
            get
            {
                return customerId;
            }
            set
            {
                customerId = value;
                OnPropertyChanged();
            }
        }

        // If the customer is not the actual login customer
        private bool isNotLoginCustomer;
        public bool IsNotLoginCustomer
        {
            get
            {
                return isNotLoginCustomer;
            }
            set
            {
                isNotLoginCustomer = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsLoginCustomer));
            }
        }

        // The opposite of IsNotLoginCustomer
        public bool IsLoginCustomer
        {
            get
            {
                return !isNotLoginCustomer;
            }
        }

        // Hide the password in the form
        private bool hidePassword;
        public bool HidePassword
        {
            get
            {
                return hidePassword;
            }
            set
            {
                if (hidePassword != value)
                {
                    hidePassword = value;
                    PasswordButtonText = value ? Constants.ShowPassword : Constants.HidePassword;
                    OnPropertyChanged();
                }
            }
        }

        private string passwordButtonText;
        public string PasswordButtonText
        {
            get
            {
                return passwordButtonText;
            }
            set
            {
                passwordButtonText = value;
                OnPropertyChanged();
            }
        }

        // The form that has not been changed to compare with the database form to see if there's been any changes
        private CustomerForm nonChangedForm;

        #region Commands

        public RelayCommand SearchCustomerCmd { get; set; }
        public RelayCommand OnLoadCmd { get; set; }
        public RelayCommand SeePasswordCmd { get; set; }
        public RelayCommand NewCmd { get; set; }
        public RelayCommand ShowAccountsCmd { get; set; }

        #endregion

        #endregion

        public CustomerVM(IViewNavigationService navigationService, ICustomerFacade facade) : base(navigationService, facade)
        {
            _facade = facade;
            InitializeCommands();
        }

        protected override void InitializeCommands()
        {
            SearchCustomerCmd = new(x => SearchCustomer(), x => CanSearchCustomer());
            OnLoadCmd = new(x => Load(), x => true);
            SeePasswordCmd = new(x => ShowPassword(), x => true);
            NewCmd = new(x => New(), x => true);
            SaveCmd = new(x => Save(), x => CanSave());
            DeleteCmd = new(x => Delete(), x => CanDelete());
            ShowAccountsCmd = new(x => ShowAccounts(), x => Form.Id != 0);
        }

        #region Commands

        private bool CanSearchCustomer()
        {
            return CustomerId.HasValue;
        }

        private void SearchCustomer()
        {
            // If the form has been changed, and we want to see another customer, we need to ask if the user wants to save the changes
            if (CheckIfChanged())
            {
                return;
            }

            // Hide the password of the new user for security reasons
            HidePassword = true;
            Form = _facade.Get(CustomerId!.Value);
            // Copy the form
            nonChangedForm = (CustomerForm)Form.Clone();

            if (Form is not null)
            {
                // Check if the form is the actual login customer, if not, it can be deleted
                IsNotLoginCustomer = Form.Id != Session.Instance.LoggedCustomerId;
                CanBeDeleted = IsNotLoginCustomer;
                IsSaved = true;
            }
        }

        private void Load()
        {
            // Set the actual login customer as the first customer to show
            CustomerId = Session.Instance.LoggedCustomerId;
            SearchCustomer();
        }

        private void ShowPassword()
        {
            HidePassword = !HidePassword;
        }

        private void New()
        {
            if (CheckIfChanged())
            {
                return;
            }

            ClearForm();
        }

        private void Save()
        {
            // If the form doesn't have an id, it's a new form
            if (Form.Id != 0)
            {
                UpdateForm();
            }
            else
            {
                AddForm();
            }

            IsSaved = true;
        }

        private void Delete()
        {
            if (_facade.Delete(Form.Id))
            {
                MessageBox.Show(string.Format(Constants.CustomerDeleted, Form.Username), Constants.MsgBoxTitleInformation,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
        }

        private void ShowAccounts()
        {
            _navigationService.NavigateTo(nameof(AccountView), Form.Id);
        }

        #endregion

        #region Helper

        private void ClearForm()
        {
            Form = new();
            IsNotLoginCustomer = false;
            HidePassword = true;
            CustomerId = null;
            IsSaved = true;
            CanBeSaved = false;
            CanBeDeleted = false;
        }

        private void AddForm()
        {
            // Check if the username already exists, if it exists, deny the creation of the new user
            if (_facade.ExistsUsername(Form.Username))
            {
                MessageBox.Show(string.Format(Constants.UsernameExists, Form.Username), Constants.MsgBoxTitleError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Form = _facade.Add(Form);
            CustomerId = Form.Id;
            MessageBox.Show(string.Format(Constants.CustomerAdded, Form.Username), Constants.MsgBoxTitleInformation,
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            HidePassword = true;
            IsNotLoginCustomer = true;
        }

        private void UpdateForm()
        {
            // Get the database form that might have changed
            var dbForm = _facade.Get(Form.Id);

            // Check if the form has changed in the database
            if (dbForm.Equals(nonChangedForm))
            {
                Form = _facade.Update(Form);
                MessageBox.Show(string.Format(Constants.CustomerUpdated, Form.Username), Constants.MsgBoxTitleInformation,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                HidePassword = true;
            }
            else
            {
                MessageBox.Show(Constants.ChangesBeenMade, Constants.MsgBoxTitleInformation,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private bool CheckIfChanged()
        {
            if (!IsSaved)
            {
                var res = MessageBox.Show(Constants.ChangesPending,
                                          Constants.MsgBoxTitleInformation,
                                          MessageBoxButtons.YesNoCancel,
                                          MessageBoxIcon.Information,
                                          MessageBoxDefaultButton.Button2);
                switch (res)
                {
                    case DialogResult.Yes:
                        Save();
                        break;
                    case DialogResult.Cancel:
                        return true;
                }
            }

            return false;
        }

        #endregion
    }
}
