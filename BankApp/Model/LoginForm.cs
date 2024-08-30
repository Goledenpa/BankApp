using BankApp.Model.Base;

namespace BankApp.Model
{
    /// <summary>
    /// Model used to represent the login view, easier than using a <see cref="CustomerForm"/> with almost all the properties to null.
    /// </summary>
    public class LoginForm : BaseForm
    {
        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public override object Clone()
        {
            return new LoginForm
            {
                Id = Id,
                Username = Username,
                Password = Password
            };
        }
    }
}
