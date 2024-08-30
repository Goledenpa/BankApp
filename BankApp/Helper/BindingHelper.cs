namespace BankApp.Helper
{

    /// <summary>
    /// Helper class for binding data to controls
    /// </summary>
    public static class BindingHelper
    {
        public static void BindToControl(Control control, object dataSource, string propertyName, string dataMember)
        {
            control.DataBindings.Add(propertyName, dataSource, dataMember, false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public static void BindNullableToControl(Control control, object dataSource, string propertyName, string dataMember)
        {
            control.DataBindings.Add(propertyName, dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged, null);
        }

        public static void BindCollectionToDataGridView(DataGridView dataGrid, object dataSource)
        {
            BindingSource bs = new()
            { 
                DataSource = dataSource
            };

            dataGrid.DataSource = bs;
        }
    }
}
