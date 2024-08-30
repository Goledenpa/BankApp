using BankAppData.Controller.Base;
using BankAppData.DB;
using BankAppData.Model.Helper;
using BankAppData.Repository.Login;
using BankAppData.UnitOfWork;

namespace BankAppData.Controller.Login
{
    public class LoginController : Controller<LoginDB>, ILoginController
    {
        protected new readonly ILoginRepository _repository;

        public LoginController(IUnitOfWork<BankContext> unitOfWork, ILoginRepository repository)
            : base(unitOfWork, repository) 
        {
            _repository = repository;
        }

        /// <summary>
        /// Get customer by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public LoginDB? GetCustomerByUsername(string username)
        {
            return _repository.GetCustomerByUsername(username);
        }
    }
}
