namespace BankApp.Service
{

    /// <summary>
    /// Represents a service that allows navigation between views.
    /// </summary>
    public interface IViewNavigationService
    {
        void NavigateTo(string view, object? parameter = null);
    }
}
