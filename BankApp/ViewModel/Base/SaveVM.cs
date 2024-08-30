using BankApp.Base;
using BankApp.Facade.Base;
using BankApp.Model.Base;
using BankApp.Service;
using BankAppData.Config;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BankApp.ViewModel.Base
{

    /// <summary>
    /// Base class for all the VMs that can save and delete data
    /// </summary>
    /// <typeparam name="ModelForm"></typeparam>
    public abstract class SaveVM<ModelForm> : BaseVM<ModelForm>, IDataErrorInfo
                    where ModelForm : BaseForm, new()
    {

        #region Properties

        private bool isSaved;
        public bool IsSaved
        {
            get
            {
                return isSaved;
            }
            set
            {
                isSaved = value;
                OnPropertyChanged();
            }
        }

        // This is to notify the button that can be enabled to save the data
        private bool canBeSaved;
        public bool CanBeSaved
        {
            get
            {
                return canBeSaved;
            }
            set
            {
                if (canBeSaved != value)
                {
                    canBeSaved = value;
                    OnPropertyChanged();
                    SaveCmd.RaiseCanExecuteChanged();
                }
            }
        }

        // This is to notify the button that can be enabled to delete the data
        private bool canBeDeleted;
        public bool CanBeDeleted
        {
            get
            {
                return canBeDeleted;
            }
            set
            {
                if (canBeDeleted != value)
                {
                    canBeDeleted = value;
                    OnPropertyChanged();
                    DeleteCmd.RaiseCanExecuteChanged();
                }
            }
        }

        public new ModelForm Form
        {
            get
            {
                return base.Form;
            }
            set
            {
                if (value is not null)
                {
                    if (base.Form != null)
                    {
                        // Unsubscribe from the previous form
                        base.Form.PropertyChanged -= Form_PropertyChanged;
                    }
                    base.Form = value;
                    if (base.Form != null)
                    {
                        // Subscribe to the new form
                        base.Form.PropertyChanged += Form_PropertyChanged;
                    }
                    OnPropertyChanged();
                }
            }
        }

        #region Form Validation

        private string error;
        public string Error
        {
            get
            {
                return error;
            }
            set
            {
                error = value;
                OnPropertyChanged();
            }
        }

        // This is to validate the form properties
        public string this[string columnName]
        {
            get
            {
                var property = Form.GetType().GetProperty(columnName);
                if (property is null)
                {
                    return null;
                }

                var validationContext = new ValidationContext(Form) { MemberName = columnName };
                var results = new List<ValidationResult>();
                Validator.TryValidateProperty(property.GetValue(Form), validationContext, results);

                if (results.Count != 0)
                {
                    return results.First().ErrorMessage;
                }

                return null;
            }
        }

        #endregion

        #region Commands
        public RelayCommand SaveCmd { get; set; }
        public RelayCommand DeleteCmd { get; set; }

        #endregion

        #endregion
        protected SaveVM(IViewNavigationService navigationService, IBaseFacade<ModelForm> facade) : base(navigationService, facade)
        {
            IsSaved = true;
            Form.PropertyChanged += Form_PropertyChanged;
        }

        // When the any property of the form is changed, set IsSaved to false so the user can save the data and it will
        // notify if the form is not being saved when doing another action that would delete the data
        protected virtual void Form_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            IsSaved = false;
            CanBeSaved = CanSave(); // Re-evaluate CanSave whenever a property changes
            CanBeDeleted = CanDelete(); // Re-evaluate CanDelete whenever a property changes
        }

        protected virtual bool CanSave()
        {
            var properties = typeof(ModelForm).GetProperties();
            foreach (var property in properties)
            {
                if (this[property.Name] != null)
                {
                    return false;
                }
            }

            return true && !IsSaved;
        }

        // Basically, if the form id is not set, it means that the form is not set and it can't be deleted
        protected virtual bool CanDelete()
        {
            return Form.Id != 0 && Session.Instance.LoggedCustomerId != Form.Id;
        }
    }
}