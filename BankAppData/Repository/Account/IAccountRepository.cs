using BankAppData.Model;
using BankAppData.Repository.Base;

namespace BankAppData.Repository.Account
{
    public interface IAccountRepository : IRepository<AccountDB> 
    {
        IEnumerable<AccountDB> GetAll(int customerId);
    }
}
