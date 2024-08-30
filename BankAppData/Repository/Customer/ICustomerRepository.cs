using BankAppData.Model;
using BankAppData.Repository.Base;

namespace BankAppData.Repository.Customer
{
    public interface ICustomerRepository : IRepository<CustomerDB> 
    {
        public bool ExistsUsername(string username);
    }
}
