namespace BankAppData.Config
{
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
    }
}
