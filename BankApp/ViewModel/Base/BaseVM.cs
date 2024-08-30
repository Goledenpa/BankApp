using BankApp.Base;
using BankApp.Facade.Base;
using BankApp.Model.Base;
using BankApp.Service;

namespace BankApp.ViewModel.Base
{

    /// <summary>
    /// Base class for all the VMs
    /// </summary>
    /// <typeparam name="ModelForm"></typeparam>
    public abstract class BaseVM<ModelForm> : ObservableObject
        where ModelForm : BaseForm, new()
    {
        // The navigation service
        protected readonly IViewNavigationService _navigationService;
        // The facade that exposes the CRUD operations
        protected readonly IBaseFacade<ModelForm> _facade;

        private ModelForm _form;
        public ModelForm Form
        {
            get
            {
                return _form;
            }
            set
            {
                _form = value;
                OnPropertyChanged();
            }
        }

        public BaseVM(IViewNavigationService navigationService, IBaseFacade<ModelForm> facade) : base()
        {
            Form = new();
            _navigationService = navigationService;
            _facade = facade;
        }

        protected abstract void InitializeCommands();
    }
}
