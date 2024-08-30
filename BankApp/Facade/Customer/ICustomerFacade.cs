using BankApp.Facade.Base;
using BankApp.Model;

namespace BankApp.Facade.Customer
{
    public interface ICustomerFacade : IBaseFacade<CustomerForm> 
    {
        public bool ExistsUsername(string username);
    }
}
