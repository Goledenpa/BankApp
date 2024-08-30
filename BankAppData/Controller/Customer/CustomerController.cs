using BankAppData.Controller.Base;
using BankAppData.DB;
using BankAppData.Model;
using BankAppData.Repository.Customer;
using BankAppData.UnitOfWork;

namespace BankAppData.Controller.Customer
{
    public class CustomerController : Controller<CustomerDB>, ICustomerController
    {
        private new readonly ICustomerRepository _repository;

        public CustomerController(IUnitOfWork<BankContext> unitOfWork, ICustomerRepository repository) 
            : base(unitOfWork, repository) 
        {
            _repository = repository;
        }

        /// <summary>
        /// Check if username exists
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool ExistsUsername(string username)
        {
            return _repository.ExistsUsername(username);
        }
    }
}
