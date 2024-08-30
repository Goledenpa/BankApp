namespace BankAppData.Model
{
    /// <summary>
    /// Customer class to store customer information
    /// </summary>
    public class CustomerDB
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public ICollection<AccountDB> Accounts { get; set; }

        public CustomerDB()
        {
            Accounts = [];
        }
    }
}
