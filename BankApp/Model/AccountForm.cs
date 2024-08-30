using BankApp.Model.Base;

namespace BankApp.Model
{
    public class AccountForm : BaseForm
    {
        private string accountNumber;
        public string AccountNumber
        {
            get
            {
                return accountNumber;
            }
            set
            {
                accountNumber = value;
                OnPropertyChanged();
            }
        }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnPropertyChanged();
            }
        }

        private int customerId;
        public int CustomerId
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

        public override object Clone()
        {
            return new AccountForm
            {
                Id = Id,
                AccountNumber = AccountNumber,
                Description = Description,
                CustomerId = CustomerId
            };
        }
    }
}
