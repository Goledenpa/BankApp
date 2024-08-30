using BankApp.Facade.Base;
using BankApp.Helper;
using BankApp.Model;
using BankAppData.Controller.Login;
using BankAppData.Model.Helper;

namespace BankApp.Facade.Login
{
    public class LoginFacade : BaseFacade<LoginForm, LoginDB>, ILoginFacade
    {
        protected new readonly ILoginController _controller;

        public LoginFacade(ILoginController controller)
            : base(controller)
        {
            _controller = controller;
        }

        /// <summary>
        /// Login method to check if the user exists in the database
        /// </summary>
        /// <param name="form">The data needed to login</param>
        /// <returns></returns>
        public bool Login(LoginForm form)
        {
            var customer = _controller.GetCustomerByUsername(form.Username);

            // We should use some form of hashing when storing the password and compare it
            if (customer is not null && form.Password.Equals(customer.Password))
            {
                form.Id = customer.Id;
                return true;
            }

            return false;
        }

        public override LoginDB AsBDModel(LoginForm form)
        {
            return new()
            {
                Username = form.Username,
                Password = form.Password,
            };
        }

        public override LoginForm AsForm(LoginDB bdModel)
        {
            return new()
            {
                Id = bdModel.Id,
                Username = bdModel.Username,
                Password = bdModel.Password
            };
        }
    }
}
