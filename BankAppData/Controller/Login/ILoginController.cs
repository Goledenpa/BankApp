using BankAppData.Controller.Base;
using BankAppData.Model.Helper;

namespace BankAppData.Controller.Login
{
    public interface ILoginController : IController<LoginDB>    
    {
        LoginDB? GetCustomerByUsername(string username);
    }
}