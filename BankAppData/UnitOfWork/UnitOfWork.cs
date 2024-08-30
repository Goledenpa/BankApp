using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;

namespace BankAppData.UnitOfWork
{
    /// <summary>
    /// Unit of work class, which is responsible for managing the database transaction and operations such as commit, rollback, and save.
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>
        where TContext : DbContext, new()
    {
        private bool _disposed;
        private string _errorMessage = string.Empty;
        private IDbContextTransaction _objTransaction;
        private readonly string _transactionName = "first";


        private readonly TContext _context;
        public TContext Context
        {
            get
            {
                return _context;
            }
        }

        public UnitOfWork()
        {
            _context = new TContext();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Commit()
        {
            _objTransaction.Commit();
            _objTransaction.Dispose();
        }

        public void CreateTransaction()
        {
            if (!CanConnect())
            {
                throw new Exception("Database connection failed");
            }

            _objTransaction = _context.Database.BeginTransaction();
            _objTransaction.CreateSavepoint(_transactionName);
        }

        public void Rollback()
        {
            if (_context.Database.CurrentTransaction is null)
            {
                throw new InvalidOperationException("Transaction is not created");
            }

            _objTransaction.RollbackToSavepoint(_transactionName);
            _objTransaction.Dispose();
        }

        public void ClearContext()
        {
            _context.ChangeTracker.Clear();
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (ValidationException vEx)
            {
                _errorMessage = vEx.Message;
                throw new Exception(_errorMessage, vEx);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                    _disposed = true;
                }
            }
        }

        private bool CanConnect()
        {
            return _context.Database.CanConnect();
        }
    }
}
