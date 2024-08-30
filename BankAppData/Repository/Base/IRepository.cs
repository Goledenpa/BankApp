namespace BankAppData.Repository.Base
{

    /// <summary>
    /// Interface for the Repository pattern
    /// </summary>
    /// <typeparam name="TDatabase"></typeparam>
    public interface IRepository<TDatabase> where TDatabase : class
    {
        TDatabase Add(TDatabase entity);
        bool Delete(int id);
        TDatabase? Get(int id);
        IEnumerable<TDatabase> GetAll();
        TDatabase Update(TDatabase entity);
    }
}
