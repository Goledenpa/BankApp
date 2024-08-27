namespace BankAppData.Model
{
    public class Client
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

        public ICollection<Account> Accounts { get; set; }

        public Client()
        {
            Accounts = [];
        }
    }
}
