using BankApp.Config;
using BankApp.Model.Base;
using System.ComponentModel.DataAnnotations;

namespace BankApp.Model
{
    public class CustomerForm : BaseForm, IEquatable<CustomerForm>
    {
        private string firstName;
        [Required(ErrorMessage = Constants.FirstNameRequired)]
        [MaxLength(35, ErrorMessage = Constants.FirstNameTooLong)]
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (firstName != value.Trim())
                {
                    firstName = value.Trim();
                    OnPropertyChanged();
                }
            }
        }

        private string lastName;
        [Required(ErrorMessage = Constants.LastNameRequired)]
        [MaxLength(35, ErrorMessage = Constants.LastNameTooLong)]
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (lastName != value.Trim())
                {
                    lastName = value.Trim();
                    OnPropertyChanged();
                }
            }
        }

        private string username;
        [Required(ErrorMessage = Constants.UsernameRequired)]
        [MaxLength(15, ErrorMessage = Constants.UsernameRequired)]
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                if (username != value.Trim())
                {
                    username = value.Trim();
                    OnPropertyChanged();
                }
            }
        }

        private string password;
        [Required(ErrorMessage = Constants.PasswordRequired)]
        [MinLength(3, ErrorMessage = Constants.PasswordLength)]
        [MaxLength(24, ErrorMessage = Constants.PasswordLength)]
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (password != value.Trim())
                {
                    password = value.Trim();
                    OnPropertyChanged();
                }
            }
        }

        private string country;
        [Required(ErrorMessage = Constants.CountryRequired)]
        [MaxLength(50, ErrorMessage = Constants.CountryTooLong)]
        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                if (country != value.Trim())
                {
                    country = value.Trim();
                    OnPropertyChanged();
                }
            }
        }

        private string region;
        [Required(ErrorMessage = Constants.RegionRequired)]
        [MaxLength(50, ErrorMessage = Constants.RegionTooLong)]
        public string Region
        {
            get
            {
                return region;
            }
            set
            {
                if (region != value.Trim())
                {
                    region = value.Trim();
                    OnPropertyChanged();
                }
            }
        }

        private string city;
        [Required(ErrorMessage = Constants.CityRequired)]
        [MaxLength(50, ErrorMessage = Constants.CityTooLong)]
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                if (city != value.Trim())
                {
                    city = value.Trim();
                    OnPropertyChanged();
                }
            }
        }

        private string address;
        [Required(ErrorMessage = Constants.AddressRequired)]
        [MaxLength(100, ErrorMessage = Constants.AddressTooLong)]
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                if (address != value.Trim())
                {
                    address = value.Trim();
                    OnPropertyChanged();
                }
            }
        }

        private List<AccountForm> accounts;
        public List<AccountForm> Accounts
        {
            get
            {
                return accounts;
            }
            set
            {
                accounts = value;
                OnPropertyChanged();
            }
        }

        public override object Clone()
        {
            return new CustomerForm
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Username = Username,
                Password = Password,
                Country = Country,
                Region = Region,
                City = City,
                Address = Address,
                Accounts = Accounts
            };
        }

        public bool Equals(CustomerForm? other)
        {
            if (other is null)
            {
                return false;
            }

            return FirstName == other.FirstName &&
                LastName == other.LastName &&
                Username == other.Username &&
                Password == other.Password &&
                Country == other.Country &&
                Region == other.Region &&
                City == other.City &&
                Address == other.Address;
        }
    }
}
