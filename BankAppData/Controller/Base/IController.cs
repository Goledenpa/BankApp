namespace BankAppData.Controller.Base
{

    /// <summary>
    /// Interface for the controller classes
    /// </summary>
    /// <typeparam name="TDatabase"></typeparam>
    public interface IController<TDatabase>
        where TDatabase : class, new()
    {
        TDatabase Add(TDatabase entity);
        bool Delete(int id);
        TDatabase? Get(int id);
        IEnumerable<TDatabase> GetAll();
        TDatabase Update(TDatabase entity);
    }
}
