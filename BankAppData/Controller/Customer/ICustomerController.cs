using BankAppData.Controller.Base;
using BankAppData.Model;

namespace BankAppData.Controller.Customer
{
    public interface ICustomerController : IController<CustomerDB>
    {
        public bool ExistsUsername(string username);
    }
}
