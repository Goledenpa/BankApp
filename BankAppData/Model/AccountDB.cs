namespace BankAppData.Model
{
    /// <summary>
    /// AccountDB class
    /// </summary>
    public class AccountDB
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }

        public CustomerDB Client { get; set; }
    }
}
