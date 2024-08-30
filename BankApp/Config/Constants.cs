namespace BankApp.Config
{
    public static class Constants
    {
        public const string CustomerAdded = "The customer {0} has been added correctly";
        public const string CustomerUpdated = "The customer {0} has been updated correctly";
        public const string CustomerDeleted = "The customer {0} has been deleted correctly";

        public const string ChangesPending = "There are changes not saved, do you want to save them?";
        public const string ChangesBeenMade = "There are changes made to this customer, please refresh this";
        public const string PasswordPlaceholder = "ThisWillGet***";

        public const string MsgBoxTitleInformation = "Information";
        public const string MsgBoxTitleError = "Error";

        public const string FirstNameRequired = "First name is required";
        public const string LastNameRequired = "Last name is required";
        public const string UsernameRequired = "Username is required";
        public const string PasswordRequired = "Password is required";
        public const string CountryRequired = "Country is required";
        public const string RegionRequired = "Region is required";
        public const string CityRequired = "City is required";
        public const string AddressRequired = "Address is required";

        public const string FirstNameTooLong = "First name is too long";
        public const string LastNameTooLong = "Last name is too long";
        public const string UsernameTooLong = "Username is too long";
        public const string PasswordLength = "Password must be between 3 and 24 characters";
        public const string CountryTooLong = "Country is too long";
        public const string RegionTooLong = "Region is too long";
        public const string CityTooLong = "City is too long";
        public const string AddressTooLong = "Address is too long";

        public const string ErrorGetEntity = "The {0} with ID {1} does not exists";
        public const string ErrorAddEntity = "The {0} couldn't be added";
        public const string UsernameExists = "The username {0} already exists";

        public const string ShowPassword = "Show";
        public const string HidePassword = "Hide";
    }
}
