using BankAppData.DB;
using BankAppData.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace BankAppData.Repository.Base
{

    /// <summary>
    /// Base class for the Repository pattern 
    /// </summary>
    /// <typeparam name="TDatabase"></typeparam>
    public abstract class Repository<TDatabase> : IRepository<TDatabase>, IDisposable where TDatabase : class
    {
        private DbSet<TDatabase> _entities;
        protected bool _disposed;

        public BankContext Context { get; set; }

        public virtual IQueryable<TDatabase> Table
        {
            get
            {
                return _entities;
            }
        }

        public virtual DbSet<TDatabase> Entities
        {
            get
            {
                _entities ??= Context.Set<TDatabase>();
                return _entities;
            }
        }

        public Repository(IUnitOfWork<BankContext> unitOfWork) : this(unitOfWork.Context) { }

        protected Repository(BankContext context)
        {
            Context = context;
            _disposed = false;
        }

        public abstract TDatabase Add(TDatabase entity);
        public abstract bool Delete(int id);
        public abstract TDatabase Get(int id);
        public abstract IEnumerable<TDatabase> GetAll();
        public abstract TDatabase Update(TDatabase entity);

        public void Dispose()
        {
            if (Context is not null)
            {
                Context.Dispose();
                GC.SuppressFinalize(this);
                _disposed = true;
            }
        }
    }
}
