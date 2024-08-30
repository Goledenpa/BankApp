namespace BankAppData.Config
{
    /// <summary>
    /// Class to store the session data and the connection string
    /// </summary>
    public sealed class Session
    {
        private static Session? _instance = null;
        public static Session Instance
        {
            get
            {
                _instance ??= new Session();
                return _instance;
            }
        }
        public string ConnectionString { get; set; }
        public int LoggedCustomerId { get; set; }
    }
}
