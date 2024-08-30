using BankAppData.Controller.Base;
using BankAppData.DB;
using BankAppData.Model;
using BankAppData.Repository.Account;
using BankAppData.UnitOfWork;

namespace BankAppData.Controller.Account
{
    public class AccountController : Controller<AccountDB>, IAccountController
    {
        private new readonly IAccountRepository _repository;
        public AccountController(IUnitOfWork<BankContext> unitOfWork, IAccountRepository repository) 
            : base(unitOfWork, repository) 
        {
            _repository = repository;
        }

        /// <summary>
        /// Get all accounts for a customer
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public IEnumerable<AccountDB> GetAll(int customerId)
        {
            return _repository.GetAll(customerId);
        }
    }
}
