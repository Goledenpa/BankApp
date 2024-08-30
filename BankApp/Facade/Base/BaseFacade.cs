using BankApp.Config;
using BankApp.Model.Base;
using BankAppData.Controller.Base;

namespace BankApp.Facade.Base
{
    /// <summary>
    /// Base facade class that implements the IBaseFacade interface, which contains the CRUD operations and communicates with the controller.
    /// </summary>
    /// <typeparam name="ModelForm">The class of the presentation layer</typeparam>
    /// <typeparam name="BDModel">The class of the data layer</typeparam>
    public abstract class BaseFacade<ModelForm, BDModel> : IBaseFacade<ModelForm>
        where ModelForm : BaseForm, new()
        where BDModel : class, new()
    {
        protected readonly IController<BDModel> _controller;

        protected BaseFacade(IController<BDModel> controller)
        {
            _controller = controller;
        }

        public virtual ModelForm Add(ModelForm form)
        {
            var bdForm = AsBDModel(form);

            var res = _controller.Add(bdForm);

            return res is null ? throw new Exception(string.Format(Constants.ErrorAddEntity, GetTypeName())) : AsForm(res);
        }

        public virtual bool Delete(int id)
        {
            return _controller.Delete(id);
        }

        public virtual ModelForm Get(int id)
        {
            var res = _controller.Get(id);

            return res is null ? throw new Exception(string.Format(Constants.ErrorGetEntity, GetTypeName(), id)) : AsForm(res);
        }

        public virtual List<ModelForm> GetAll()
        {
            return _controller.GetAll().Select(AsForm).ToList();
        }

        public virtual ModelForm Update(ModelForm form)
        {
            var bdForm = AsBDModel(form);

            var res = _controller.Update(bdForm);

            return AsForm(res);
        }

        public abstract BDModel AsBDModel(ModelForm form);
        public abstract ModelForm AsForm(BDModel bdModel);

        private string GetTypeName()
        {
            return GetType().Name.Replace("Facade", string.Empty).ToLower();
        }
    }
}
