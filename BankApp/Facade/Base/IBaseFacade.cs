using BankApp.Model.Base;

namespace BankApp.Facade.Base
{
    /// <summary>
    /// Is a generic interface that defines the basic operations of a facade.
    /// </summary>
    /// <typeparam name="ModelForm"></typeparam>
    public interface IBaseFacade<ModelForm>
        where ModelForm : BaseForm, new()
    {
        ModelForm Add(ModelForm form);
        bool Delete(int id);
        ModelForm Get(int id);
        List<ModelForm> GetAll();
        ModelForm Update(ModelForm form);
    }
}
