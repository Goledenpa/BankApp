using BankApp.Facade.Base;
using BankApp.Model;
using BankAppData.Controller.Account;
using BankAppData.Model;

namespace BankApp.Facade.Account
{
    public class AccountFacade : BaseFacade<AccountForm, AccountDB>, IAccountFacade
    {
        private new readonly IAccountController _controller;

        public AccountFacade(IAccountController controller) 
            : base(controller) 
        {
            _controller = controller;
        }

        public List<AccountForm> GetAll(int customerId)
        {
            return _controller.GetAll(customerId)
                .Select(AsForm)
                .ToList();
        }

        public override AccountDB AsBDModel(AccountForm form)
        {
            return new()
            {
                Id = form.Id,
                AccountNumber = form.AccountNumber,
                CustomerId = form.CustomerId,
                Description = form.Description,
            };
        }

        public override AccountForm AsForm(AccountDB bdModel)
        {
            return new()
            {
                Id = bdModel.Id,
                AccountNumber = bdModel.AccountNumber,
                CustomerId = bdModel.CustomerId,
                Description = bdModel.Description,
            };
        }
    }
}
