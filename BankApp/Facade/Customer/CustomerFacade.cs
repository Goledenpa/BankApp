using BankApp.Facade.Base;
using BankApp.Model;
using BankAppData.Controller.Customer;
using BankAppData.Model;

namespace BankApp.Facade.Customer
{
    public class CustomerFacade : BaseFacade<CustomerForm, CustomerDB>, ICustomerFacade
    {
        private new readonly ICustomerController _controller;

        public CustomerFacade(ICustomerController controller)
            : base(controller)
        {
            _controller = controller;
        }

        public bool ExistsUsername(string username)
        {
            return _controller.ExistsUsername(username);
        }

        public override CustomerDB AsBDModel(CustomerForm form)
        {
            return new()
            {
                Id = form.Id,
                Address = form.Address,
                City = form.City,
                Country = form.Country,
                FirstName = form.FirstName,
                LastName = form.LastName,
                Password = form.Password,
                Region = form.Region,
                Username = form.Username
            };
        }

        public override CustomerForm AsForm(CustomerDB bdModel)
        {
            return new()
            {
                Id = bdModel.Id,
                Address = bdModel.Address,
                City = bdModel.City,
                Country = bdModel.Country,
                FirstName = bdModel.FirstName,
                LastName = bdModel.LastName,
                Password = bdModel.Password,
                Region = bdModel.Region,
                Username = bdModel.Username
            };
        }
    }
}
