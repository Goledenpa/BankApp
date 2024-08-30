using BankAppData.Model.Helper;
using BankAppData.Repository.Base;

namespace BankAppData.Repository.Login
{
    public interface ILoginRepository : IRepository<LoginDB>
    {
        LoginDB? GetCustomerByUsername(string username);
    }
}
