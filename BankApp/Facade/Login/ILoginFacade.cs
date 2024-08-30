using BankApp.Facade.Base;
using BankApp.Model;

namespace BankApp.Facade.Login
{
    public interface ILoginFacade : IBaseFacade<LoginForm> 
    {
        bool Login(LoginForm form);
    }
}