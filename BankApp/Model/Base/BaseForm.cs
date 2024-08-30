using BankApp.Base;

namespace BankApp.Model.Base
{
    /// <summary>
    /// Base class for all models
    /// </summary>
    public abstract class BaseForm : ObservableObject, ICloneable
    {
        private int id;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        public abstract object Clone();
    }
}
