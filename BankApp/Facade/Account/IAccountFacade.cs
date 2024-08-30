using BankApp.Facade.Base;
using BankApp.Model;

namespace BankApp.Facade.Account
{
    public interface IAccountFacade : IBaseFacade<AccountForm> 
    {
        // Method to get all accounts of a customer
        public List<AccountForm> GetAll(int customerId);
    }
}
