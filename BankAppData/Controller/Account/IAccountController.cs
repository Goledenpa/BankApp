using BankAppData.Controller.Base;
using BankAppData.Model;

namespace BankAppData.Controller.Account
{
    public interface IAccountController : IController<AccountDB> 
    {
        public IEnumerable<AccountDB> GetAll(int customerId);
    }
}
