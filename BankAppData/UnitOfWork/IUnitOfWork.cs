namespace BankAppData.UnitOfWork
{

    /// <summary>
    /// Interface for Unit of Work
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public interface IUnitOfWork<out TContext> : IDisposable
        where TContext : IDisposable, new()
    {
        TContext Context { get; }
        void CreateTransaction();
        void Commit();
        void Rollback();
        void Save();
        void ClearContext();
    }
}
